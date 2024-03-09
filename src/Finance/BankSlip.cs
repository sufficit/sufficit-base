using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Finance
{
    public class BankSlip : BankSlipInfo
    {        
        [JsonPropertyOrder(5)]
        [JsonPropertyName("assignor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Assignor Assignor { get; set; } = default!;

        [JsonPropertyOrder(5)]
        [JsonPropertyName("payer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Payer Payer { get; set; } = default!;
    }
}
