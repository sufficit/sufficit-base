using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Ledger kinds of financial payments (money received), as stored in <c>fina_financial_records.kind</c>.
    ///     A payment is not a call-credit purchase: it never adds call credit by itself.
    ///     Every producer and reader must use these constants, so a future rename touches one place.
    /// </summary>
    /// <remarks>
    ///     Format: "&lt;4-letter code&gt; - &lt;title&gt;", lower case without accents (the ledger normalizes kinds).
    ///     Until 13/11/2026 payments were stored as "rec? - recarga ..."; <see cref="Legacy"/> maps them.
    /// </remarks>
    public static class PaymentKinds
    {
        public const string BankSlip = "pagb - pagamento boleto";
        public const string Card = "pagc - pagamento cartao";
        public const string Transfer = "pagt - pagamento ted";
        public const string MercadoPago = "pagm - pagamento mercado pago";
        public const string Deposit = "pagp - pagamento deposito";
        public const string Cash = "pagd - pagamento dinheiro";
        public const string Check = "pagq - pagamento cheque";

        /// <summary>All current payment kinds.</summary>
        public static IReadOnlyList<string> All { get; } = new[] { BankSlip, Card, Transfer, MercadoPago, Deposit, Cash, Check };

        /// <summary>Former stored kind → current kind (data migration and transition reads).</summary>
        public static IReadOnlyDictionary<string, string> Legacy { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["recb - recarga boleto"] = BankSlip,
            ["recb - pagamento boleto"] = BankSlip,
            ["recc - recarga cartao"] = Card,
            ["recc - recarga cartão"] = Card,
            ["recc - pagamento cartao"] = Card,
            ["recc - pagamento cartão"] = Card,
            ["recc - recarga cheque"] = Check,
            ["rect - recarga ted"] = Transfer,
            ["rect - pagamento ted"] = Transfer,
            ["recm - recarga mercado pago"] = MercadoPago,
            ["recm - pagamento mercado pago"] = MercadoPago,
            ["recp - recarga deposito"] = Deposit,
            ["recp - pagamento deposito"] = Deposit,
            ["recd - recarga dinheiro"] = Cash,
        };

        /// <summary>4-letter code of a kind ("pagb - pagamento boleto" → "pagb").</summary>
        public static string Code(string? kind)
        {
            if (string.IsNullOrWhiteSpace(kind)) return string.Empty;
            var value = kind!.Trim();
            var separator = value.IndexOf(' ');
            return (separator < 0 ? value : value.Substring(0, separator)).ToLowerInvariant();
        }

        /// <summary>Current kind for a stored value, mapping former titles; null when it is not a payment.</summary>
        public static string? Canonical(string? kind)
        {
            if (string.IsNullOrWhiteSpace(kind)) return null;
            var value = kind!.Trim();
            if (Legacy.TryGetValue(value, out var mapped)) return mapped;
            return All.FirstOrDefault(x => string.Equals(x, value, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>True for current and former payment kinds; also accepts a bare code ("pagb", "recb").</summary>
        public static bool IsPayment(string? kind)
        {
            var code = Code(kind);
            return All.Any(x => Code(x) == code) || Legacy.Keys.Any(x => Code(x) == code);
        }

        /// <summary>True when both values denote the same payment kind, whatever title or generation they carry.</summary>
        public static bool Same(string? stored, string current)
        {
            var a = Canonical(stored) ?? Canonical(BareToCurrent(Code(stored)));
            var b = Canonical(current) ?? Canonical(BareToCurrent(Code(current)));
            return a != null && a == b;
        }

        private static string? BareToCurrent(string code)
            => All.FirstOrDefault(x => Code(x) == code)
               ?? Legacy.FirstOrDefault(x => Code(x.Key) == code).Value;
    }
}
