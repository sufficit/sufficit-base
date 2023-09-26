using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Sales
{
    public class Customer
    {
        public Guid Id { get; set; }

        /// <summary>
        ///     Month day that expires the services, customer preferences
        /// </summary>
        [Range(1, 31)]
        [JsonPropertyName("dueday")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public uint? DueDay { get; set; }
    }
}