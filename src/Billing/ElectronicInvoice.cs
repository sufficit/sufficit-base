using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Billing
{
    /// <summary>
    ///   Electronic Invoice object, governament invoicing
    /// </summary>
    public class ElectronicInvoice
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        public DateTimeOffset Creation { get; set; }

        public decimal Value { get; set; }

        public Guid? XML { get; set; }

        public Guid? PDF { get; set; }
    }
}
