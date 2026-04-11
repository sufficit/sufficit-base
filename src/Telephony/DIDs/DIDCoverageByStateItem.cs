using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Sufficit.Telefonia.Classifier;

namespace Sufficit.Telephony.DIDs
{
    /// <summary>
    /// Aggregated DID coverage data for a single Brazilian state.
    /// </summary>
    public sealed class DIDCoverageByStateItem
    {
        [JsonPropertyName("region")]
        public RegionsOfBrazil Region { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("canonicalareacode")]
        public string CanonicalAreaCode { get; set; } = string.Empty;

        [JsonPropertyName("areacodes")]
        public IReadOnlyList<string> AreaCodes { get; set; } = Array.Empty<string>();

        [JsonPropertyName("didcount")]
        public uint DIDCount { get; set; }

        [JsonPropertyName("share")]
        public double Share { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
