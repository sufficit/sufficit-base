using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    /// 
    /// </summary>
    public class BillingSearchParameters
    {
        public Guid? ContextId { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string? UniqueId { get; set; }

        public TextFilter? Extension { get; set; }
    }
}
