using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Id forward preference for outbound calls
    /// </summary>
    public class IdForwardRequest : EndPointPropertyRequest
    {
        public IdForwardRequest() { base.Key = "idforward"; }

        [JsonIgnore]
        public override string Key => base.Key;

        public new IdForwardPreference? Value 
        {
            get
            {
                if (string.IsNullOrWhiteSpace(base.Value))
                    return null;

                return (IdForwardPreference)Enum.Parse(typeof(IdForwardPreference), base.Value, true);
            }
            set
            {
                // default preference as null value
                if (value == null || value == IdForwardPreference.DontCare)
                    base.Value = null;
                else 
                    base.Value = value.ToString()!.ToLowerInvariant();
            }
        }
    }
}
