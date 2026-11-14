using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>
    /// Selects the commission lines a withdrawal document covers (RPA or invoice guidance).
    /// With a competence, every non-reversed line of that month; without it, the lines still released.
    /// </summary>
    public class CommissionDocumentParameters
    {
        public Guid RepresentativeId { get; set; }

        /// <summary>Competence month "yyyy-MM" (America/Sao_Paulo calendar); null = released lines.</summary>
        public string? Competence { get; set; }

        /// <summary>Withholdings informed by the manager (the system never calculates taxes).</summary>
        public decimal Inss { get; set; }
        public decimal Irrf { get; set; }
        public decimal Iss { get; set; }

        /// <summary>Receipt number chosen by the manager.</summary>
        public string? Number { get; set; }

        /// <summary>Payment date printed on the receipt; null = today.</summary>
        public DateTime? Date { get; set; }
    }

    /// <summary>One party of a commission document (payer, payee or invoice taker).</summary>
    public class CommissionDocumentParty
    {
        public string Name { get; set; } = string.Empty;

        /// <summary>CPF or CNPJ, formatted.</summary>
        public string? Document { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Rg { get; set; }
        public string? Nit { get; set; }
        public string? PixKey { get; set; }
    }

    /// <summary>A commission line printed on a document.</summary>
    public class CommissionDocumentLine
    {
        public Guid EntryId { get; set; }
        public Guid CustomerId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;

        /// <summary>Competence "MM/yyyy".</summary>
        public string Competence { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public CommissionEntryStatus Status { get; set; }
    }

    /// <summary>Pre-filled RPA (Recibo de Pagamento a Autônomo) for an individual's PIX withdrawal.</summary>
    public class CommissionRpaView
    {
        public Guid RepresentativeId { get; set; }
        public CommissionPayeeType PayeeType { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Competence { get; set; }
        public CommissionDocumentParty Payer { get; set; } = new CommissionDocumentParty();
        public CommissionDocumentParty Payee { get; set; } = new CommissionDocumentParty();
        public List<CommissionDocumentLine> Lines { get; set; } = new List<CommissionDocumentLine>();

        /// <summary>Service description following the financial record convention.</summary>
        public string Description { get; set; } = string.Empty;
        public decimal Gross { get; set; }
        public decimal Inss { get; set; }
        public decimal Irrf { get; set; }
        public decimal Iss { get; set; }
        public decimal Net { get; set; }

        /// <summary>Data still missing in the registry (pt-BR labels); the document prints blanks for them.</summary>
        public List<string> Missing { get; set; } = new List<string>();
    }

    /// <summary>What a company representative must write on the NFS-e it issues to Sufficit.</summary>
    public class CommissionInvoiceGuide
    {
        public Guid RepresentativeId { get; set; }
        public CommissionPayeeType PayeeType { get; set; }
        public string? Competence { get; set; }
        public CommissionDocumentParty Taker { get; set; } = new CommissionDocumentParty();
        public CommissionDocumentParty Issuer { get; set; } = new CommissionDocumentParty();
        public List<CommissionDocumentLine> Lines { get; set; } = new List<CommissionDocumentLine>();
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public List<string> Missing { get; set; } = new List<string>();
    }
}
