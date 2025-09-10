using System;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.Templates
{
    /// <summary>
    /// Types of variables that can be used in message templates
    /// </summary>
    public enum TemplateVariableType
    {
        /// <summary>
        /// Simple text string
        /// </summary>
        String,

        /// <summary>
        /// Numeric value
        /// </summary>
        Number,

        /// <summary>
        /// Email address with validation
        /// </summary>
        Email,

        /// <summary>
        /// Phone number with validation
        /// </summary>
        Phone,

        /// <summary>
        /// Date/time value
        /// </summary>
        DateTime,

        /// <summary>
        /// Boolean true/false value
        /// </summary>
        Boolean
    }
}
