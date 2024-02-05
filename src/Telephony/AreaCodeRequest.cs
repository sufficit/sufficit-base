using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Region prefix for dial out requests
    /// </summary>
    public class AreaCodeRequest : EndPointPropertyRequest
    {
        public AreaCodeRequest() : base("areacode") { }

        [JsonIgnore]
        public override string Key => base.Key;

        [JsonPropertyName("number")]
        [Range(11, 99)]
        public uint? Number 
        { 
            get {
                return uint.TryParse(base.Value, out uint number) ? number : 0;
            }
            set {
                if (value.HasValue)
                    base.Value = value.ToString();
                else 
                    base.Value = null; 
            } 
        }

        [JsonIgnore]
        public override string? Value { get => base.Value; set => base.Value = value; }
    }
}
