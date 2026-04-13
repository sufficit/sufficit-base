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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RegionsOfBrazil? Region { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyName("canonicalareacode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CanonicalAreaCode { get; set; }

        [JsonPropertyName("areacodes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<string>? AreaCodes { get; set; }

        [JsonPropertyName("didcount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? DIDCount { get; set; }

        [JsonPropertyName("share")]
        public double Share { get; set; }

        [JsonPropertyName("latitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Longitude { get; set; }

        public DIDCoverageByStateItem ToPublicProjection()
            => new()
            {
                UF = UF,
                State = State,
                Share = Share
            };
    }
}
