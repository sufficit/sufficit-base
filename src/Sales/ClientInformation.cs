using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Sales
{
    public class ClientInformation : IClient, IIndex
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Activity { get; set; }

        /// <summary>
        ///     Total value amount of filtered records
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///     Total count of filtered records
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public uint Total { get; set; }

        /// <summary>
        ///     Prefered due day
        /// </summary>
        [JsonPropertyName("dueday")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        public uint? DueDay { get; set; }
    }
}
