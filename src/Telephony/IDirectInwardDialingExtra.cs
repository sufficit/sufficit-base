using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public interface IDirectInwardDialingExtra
    {
        /// <inheritdoc cref="DirectInwardDialingV1.Description"/>        
        string? Description { get; }

        /// <inheritdoc cref="DirectInwardDialingV1.Tags"/>     
        string? Tags { get; }
    }
}
