using System;

namespace Sufficit.Sales
{
    /// <summary>Lifecycle of a sales representative registration.</summary>
    public enum RepresentativeStatus { Active = 1, Inactive = 2 }

    /// <summary>How the representative prefers to receive released commissions.</summary>
    public enum CommissionPayoutMethod { Balance = 1, Pix = 2 }

    /// <summary>Legal nature of the payee, needed for the payment receipt (RPA for individuals).</summary>
    public enum CommissionPayeeType { Individual = 1, Company = 2 }

    /// <summary>
    /// A contact registered as sales representative. The identifier is the contact identifier,
    /// so the representative keeps its existing financial account and permissions.
    /// </summary>
    public class SalesRepresentative
    {
        /// <summary>Contact identifier of the representative.</summary>
        public Guid Id { get; set; }

        /// <summary>Display title, filled from the contact on reads.</summary>
        public string Title { get; set; } = string.Empty;

        public RepresentativeStatus Status { get; set; } = RepresentativeStatus.Active;

        /// <summary>Default payout preference; each payout may still choose another method.</summary>
        public CommissionPayoutMethod PayoutMethod { get; set; } = CommissionPayoutMethod.Balance;

        public CommissionPayeeType PayeeType { get; set; } = CommissionPayeeType.Individual;

        /// <summary>CPF or CNPJ (digits only) used on receipts.</summary>
        public string? Document { get; set; }

        public string? PixKey { get; set; }

        /// <summary>Commission policy applied when an assignment does not choose one.</summary>
        public Guid? DefaultPolicyId { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
    }
}
