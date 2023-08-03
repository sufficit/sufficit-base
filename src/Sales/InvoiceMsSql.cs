using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    public class InvoiceMsSql
    {
        public int Code { get; set; }

        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        /// <summary>
        ///     When this record was created, util to know if it was after or before the service starts
        /// </summary>
        public DateTime Timestamp { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
                
        public DateTime? Billing { get; set; }

        public DateTime Update { get; set; }

        public uint? Cliente { get; set; }

        public string? Description { get; set; }

        public string? Extra { get; set; }

        public decimal? Value { get; set; }

        public bool Renewed { get; set; }

        public string? Kind { get; set; }

        public Guid UserId { get; set; }

        public Guid? CommissionedId { get; set; }

        public decimal? Commission { get; set; }
    }
}
