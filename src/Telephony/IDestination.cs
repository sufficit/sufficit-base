using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public interface IDestination
    {
        /// <summary>
        /// Unique Id of this destination
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        Guid? Id { get; }

        /// <summary>
        /// Instance of the reference
        /// </summary>
        string TypeName { get; }

        /// <summary>
        /// Context of this destination
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        Guid? ContextId { get; }

        /// <summary>
        /// Asterisk Goto representation
        /// </summary>
        string Asterisk { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        string? Title { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Description { get; }
    }
}
