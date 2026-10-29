using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Holidays
{
    /// <summary>
    /// Holiday catalog (telp_holiday_catalogs): <see cref="National"/> applies to every client, a client adds
    /// any number of <see cref="State"/> catalogs and keeps its own (<see cref="Client"/>, including municipal holidays).
    /// </summary>
    public class HolidayCatalog
    {
        public const string National = "national", State = "state", Client = "client";

        public Guid Id { get; set; }
        public string Kind { get; set; } = National;

        /// <summary>UF, only for state catalogs.</summary>
        public string? StateCode { get; set; }

        /// <summary>Owner, only for client catalogs.</summary>
        public Guid? ContextId { get; set; }

        public string Title { get; set; } = string.Empty;
        public List<HolidayRule> Rules { get; set; } = new List<HolidayRule>();
    }

    /// <summary>
    /// One holiday, computed per year (telp_holiday_rules): <see cref="Fixed"/> day/month, <see cref="Easter"/>
    /// days from Easter Sunday (Good Friday −2, Carnival Tuesday −47) or <see cref="Date"/> one day.
    /// </summary>
    public class HolidayRule
    {
        public const string Fixed = "fixed", Easter = "easter", Date = "date";

        public Guid Id { get; set; }
        public Guid CatalogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Kind { get; set; } = Fixed;
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? EasterOffset { get; set; }
        public DateTime? OnDate { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public bool Active { get; set; } = true;

        /// <summary>Law or other reference, shown to the manager.</summary>
        public string? Source { get; set; }
    }

    /// <summary>A holiday on a given date.</summary>
    public class HolidayOccurrence
    {
        public DateTime Date { get; set; }
        public HolidayRule Rule { get; set; } = new HolidayRule();
    }
}
