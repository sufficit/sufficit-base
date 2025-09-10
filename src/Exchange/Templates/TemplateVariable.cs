using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.Templates
{
    /// <summary>
    /// Defines a variable that can be used within a message template
    /// </summary>
    public class TemplateVariable
    {
        /// <summary>
        /// Variable name (used in template as {{variable_name}})
        /// </summary>
        [JsonPropertyName("name")]
        [JsonPropertyOrder(0)]
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Type of the variable for validation
        /// </summary>
        [JsonPropertyName("type")]
        [JsonPropertyOrder(1)]
        [Required]
        public TemplateVariableType Type { get; set; }

        /// <summary>
        /// Whether this variable is required when using the template
        /// </summary>
        [JsonPropertyName("isRequired")]
        [JsonPropertyOrder(2)]
        public bool IsRequired { get; set; } = false;

        /// <summary>
        /// Default value if not provided (only for non-required variables)
        /// </summary>
        [JsonPropertyName("defaultValue")]
        [JsonPropertyOrder(3)]
        [StringLength(200)]
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Regex pattern for validation (optional)
        /// </summary>
        [JsonPropertyName("validationPattern")]
        [JsonPropertyOrder(4)]
        [StringLength(500)]
        public string? ValidationPattern { get; set; }

        /// <summary>
        /// Human-readable description of this variable
        /// </summary>
        [JsonPropertyName("description")]
        [JsonPropertyOrder(5)]
        [StringLength(200)]
        public string? Description { get; set; }
    }
}
