using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public interface IDirectInwardDialingExtra
    {
        /// <inheritdoc cref="DirectInwardDialing.Description"/>        
        string? Description { get; }

        /// <inheritdoc cref="DirectInwardDialing.Tags"/>     
        string? Tags { get; }
    }
}
