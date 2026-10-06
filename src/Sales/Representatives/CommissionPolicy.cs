using System;

namespace Sufficit.Sales
{
    /// <summary>Explicit commission unit; replaces the legacy "≤ 1 is a rate, &gt; 1 is an amount" rule.</summary>
    public enum CommissionKind { Percentage = 1, FixedAmount = 2 }

    /// <summary>
    /// How much a representative earns per paid service period and for how long.
    /// </summary>
    public class CommissionPolicy
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public CommissionKind Kind { get; set; } = CommissionKind.Percentage;

        /// <summary>Percentage points (10 = 10%) or a fixed amount in BRL, according to <see cref="Kind"/>.</summary>
        public decimal Value { get; set; }

        /// <summary>Months of recurring commission counted from the assignment start; null = no limit.</summary>
        public int? DurationMonths { get; set; } = 6;

        /// <summary>Optional catalog item restriction; null applies to every service.</summary>
        public Guid? CatalogItemId { get; set; }

        public bool Active { get; set; } = true;
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }

        /// <summary>Commission for a paid base amount (after discounts), rounded to cents.</summary>
        public decimal Calculate(decimal paidAmount)
        {
            if (paidAmount <= 0) return 0;
            var value = Kind == CommissionKind.Percentage ? paidAmount * Value / 100m : Math.Min(Value, paidAmount);
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
