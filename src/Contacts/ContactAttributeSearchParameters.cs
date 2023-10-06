using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Contacts
{
    /// <summary>
    ///     Same as <see cref="AttributeSearchParameters" /> but ContactId is required
    /// </summary>
    public class ContactAttributeSearchParameters : AttributeSearchParameters
    {
        /// <inheritdoc cref="AttributeSearchParameters.ContactId"/>
        [JsonPropertyName("contactId")]
        [Required]
        public override Guid? ContactId { get; set; }
    }
}
