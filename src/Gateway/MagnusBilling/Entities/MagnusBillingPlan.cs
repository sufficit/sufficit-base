using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling Plan entity compatible with pkg_plan table
    /// Represents billing plans in MagnusBilling system
    /// </summary>
    public class MagnusBillingPlan
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyOrder(2)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyOrder(3)]
        [JsonPropertyName("price")]
        public string Price { get; set; } = "0.0000";

        [JsonPropertyOrder(4)]
        [JsonPropertyName("signup")]
        public string Signup { get; set; } = "0.0000";

        [JsonPropertyOrder(5)]
        [JsonPropertyName("billingtype")]
        public string BillingType { get; set; } = "0";

        [JsonPropertyOrder(6)]
        [JsonPropertyName("startday")]
        public string StartDay { get; set; } = "1";

        [JsonPropertyOrder(7)]
        [JsonPropertyName("techprefix")]
        public string TechPrefix { get; set; } = string.Empty;

        [JsonPropertyOrder(8)]
        [JsonPropertyName("lcrtype")]
        public string LcrType { get; set; } = "0";

        [JsonPropertyOrder(9)]
        [JsonPropertyName("minimal_time_charge")]
        public string MinimalTimeCharge { get; set; } = "1";

        [JsonPropertyOrder(10)]
        [JsonPropertyName("minimal_time_charge_2")]
        public string MinimalTimeCharge2 { get; set; } = "1";

        [JsonPropertyOrder(11)]
        [JsonPropertyName("rounding_calltime")]
        public string RoundingCalltime { get; set; } = "0";

        [JsonPropertyOrder(12)]
        [JsonPropertyName("rounding_threshold")]
        public string RoundingThreshold { get; set; } = "0";

        [JsonPropertyOrder(13)]
        [JsonPropertyName("portabilityprefix")]
        public string PortabilityPrefix { get; set; } = string.Empty;

        [JsonPropertyOrder(14)]
        [JsonPropertyName("portabilitystripdigit")]
        public string PortabilityStripDigit { get; set; } = "0";

        [JsonPropertyOrder(15)]
        [JsonPropertyName("ini_credit")]
        public string IniCredit { get; set; } = "0.0000";

        [JsonPropertyOrder(16)]
        [JsonPropertyName("play_audio")]
        public string PlayAudio { get; set; } = "0";

        [JsonPropertyOrder(17)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}