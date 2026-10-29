using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telephony.Holidays
{
    /// <summary>Computes holiday dates per year. Pure: no database, no clock, no time zone.</summary>
    public static class HolidayCalendar
    {
        public const int MinYear = 1900, MaxYear = 2199, MaxEasterOffset = 120;

        /// <summary>Gregorian Easter Sunday (anonymous algorithm).</summary>
        public static DateTime EasterSunday(int year)
        {
            int a = year % 19, b = year / 100, c = year % 100, d = b / 4, e = b % 4, f = (b + 8) / 25, g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30, i = c / 4, k = c % 4, l = (32 + 2 * e + 2 * i - h - k) % 7, m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31, day = (h + l - 7 * m + 114) % 31 + 1;
            return new DateTime(year, month, day);
        }

        /// <summary>Date of the rule in the year, or null when it does not happen that year (out of its years, 29/02 off leap years).</summary>
        public static DateTime? Occurrence(HolidayRule rule, int year)
        {
            if (rule is null) throw new ArgumentNullException(nameof(rule));
            if (year < MinYear || year > MaxYear) return null;
            if (rule.FirstYear is int first && year < first) return null;
            if (rule.LastYear is int last && year > last) return null;
            switch (rule.Kind)
            {
                case HolidayRule.Fixed:
                    if (rule.Month is not int month || rule.Day is not int day || month < 1 || month > 12 || day < 1) return null;
                    return day <= DateTime.DaysInMonth(year, month) ? new DateTime(year, month, day) : (DateTime?)null;
                case HolidayRule.Easter:
                    if (rule.EasterOffset is not int offset || Math.Abs(offset) > MaxEasterOffset) return null;
                    var date = EasterSunday(year).AddDays(offset);
                    return date.Year == year ? date : (DateTime?)null;
                case HolidayRule.Date:
                    return rule.OnDate is DateTime on && on.Year == year ? on.Date : (DateTime?)null;
                default:
                    return null;
            }
        }

        /// <summary>Active, not excluded holidays of the year, ordered by date.</summary>
        public static IReadOnlyList<HolidayOccurrence> Occurrences(IEnumerable<HolidayRule> rules, int year, ICollection<Guid>? excluded = null)
            => (rules ?? Enumerable.Empty<HolidayRule>())
                .Where(r => r.Active && (excluded is null || !excluded.Contains(r.Id)))
                .Select(r => new { Rule = r, Date = Occurrence(r, year) })
                .Where(x => x.Date.HasValue)
                .Select(x => new HolidayOccurrence { Date = x.Date!.Value, Rule = x.Rule })
                .OrderBy(x => x.Date).ThenBy(x => x.Rule.Title, StringComparer.CurrentCulture)
                .ToList();

        /// <summary>Holidays falling on the local date (time part ignored).</summary>
        public static IReadOnlyList<HolidayRule> On(IEnumerable<HolidayRule> rules, DateTime date, ICollection<Guid>? excluded = null)
            => Occurrences(rules, date.Year, excluded).Where(o => o.Date == date.Date).Select(o => o.Rule).ToList();

        /// <summary>Portuguese message for the manager, or null when the rule is valid.</summary>
        public static string? Validate(HolidayRule rule)
        {
            if (rule is null) return "Informe o feriado.";
            if (string.IsNullOrWhiteSpace(rule.Title)) return "Dê um nome ao feriado.";
            if (rule.Title.Trim().Length > 80) return "O nome do feriado tem no máximo 80 caracteres.";
            if (rule.Source is { Length: > 160 }) return "A referência tem no máximo 160 caracteres.";
            if (rule.FirstYear is int f && (f < MinYear || f > MaxYear) || rule.LastYear is int l && (l < MinYear || l > MaxYear)) return "Ano fora do intervalo aceito.";
            if (rule.FirstYear > rule.LastYear) return "O ano inicial vem depois do ano final.";
            switch (rule.Kind)
            {
                case HolidayRule.Fixed:
                    if (rule.Month is not int month || month < 1 || month > 12) return "Escolha o mês.";
                    // 29/02 is accepted: it only happens in leap years.
                    if (rule.Day is not int day || day < 1 || day > DateTime.DaysInMonth(2000, month)) return "Esse dia não existe nesse mês.";
                    return null;
                case HolidayRule.Easter:
                    return rule.EasterOffset is int offset && Math.Abs(offset) <= MaxEasterOffset ? null : $"A distância da Páscoa vai de −{MaxEasterOffset} a {MaxEasterOffset} dias.";
                case HolidayRule.Date:
                    return rule.OnDate is DateTime on && on.Year >= MinYear && on.Year <= MaxYear ? null : "Escolha a data.";
                default:
                    return "Tipo de feriado desconhecido.";
            }
        }
    }
}
