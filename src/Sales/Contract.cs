using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Recurring services
    /// </summary>
    public class Contract
    {
        public Guid Id { get; set; }

        public Guid ContextId { get; set; }

        /// <summary>
        ///     Key for object reference, external id
        /// </summary>
        [StringLength(50)]
        [DefaultValue("")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Key { get; set; } = string.Empty;

        public string Title { get; set; } = default!;

        public decimal Value { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        /// <summary>
        ///     Should charge partial days ?
        /// </summary>
        public bool Partial { get; set; } = true;

        /// <summary>
        ///     Preferencial due day, overriding customer preferênces
        /// </summary>
        public uint? DueDay { get; set; }
    }
}
