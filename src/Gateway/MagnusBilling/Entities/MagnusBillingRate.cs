using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling Rate entity compatible with pkg_rate table
    /// Represents tariff rates in MagnusBilling system
    /// </summary>
    public class MagnusBillingRate
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyOrder(2)]
        [JsonPropertyName("id_plan")]
        public string IdPlan { get; set; } = string.Empty;

        [JsonPropertyOrder(3)]
        [JsonPropertyName("id_prefix")]
        public string IdPrefix { get; set; } = string.Empty;

        [JsonPropertyOrder(4)]
        [JsonPropertyName("rateinitial")]
        public string RateInitial { get; set; } = "0.0000";

        [JsonPropertyOrder(5)]
        [JsonPropertyName("initblock")]
        public string InitBlock { get; set; } = "1";

        [JsonPropertyOrder(6)]
        [JsonPropertyName("billingblock")]
        public string BillingBlock { get; set; } = "1";

        [JsonPropertyOrder(7)]
        [JsonPropertyName("connectcharge")]
        public string ConnectCharge { get; set; } = "0.0000";

        [JsonPropertyOrder(8)]
        [JsonPropertyName("disconnectcharge")]
        public string DisconnectCharge { get; set; } = "0.0000";

        [JsonPropertyOrder(9)]
        [JsonPropertyName("stepchargea")]
        public string StepChargeA { get; set; } = "0.0000";

        [JsonPropertyOrder(10)]
        [JsonPropertyName("chargea")]
        public string ChargeA { get; set; } = "0.0000";

        [JsonPropertyOrder(11)]
        [JsonPropertyName("timea")]
        public string TimeA { get; set; } = "0";

        [JsonPropertyOrder(12)]
        [JsonPropertyName("stepchargeb")]
        public string StepChargeB { get; set; } = "0.0000";

        [JsonPropertyOrder(13)]
        [JsonPropertyName("chargeb")]
        public string ChargeB { get; set; } = "0.0000";

        [JsonPropertyOrder(14)]
        [JsonPropertyName("timeb")]
        public string TimeB { get; set; } = "0";

        [JsonPropertyOrder(15)]
        [JsonPropertyName("stepchargec")]
        public string StepChargeC { get; set; } = "0.0000";

        [JsonPropertyOrder(16)]
        [JsonPropertyName("chargec")]
        public string ChargeC { get; set; } = "0.0000";

        [JsonPropertyOrder(17)]
        [JsonPropertyName("timec")]
        public string TimeC { get; set; } = "0";

        [JsonPropertyOrder(18)]
        [JsonPropertyName("buyrate")]
        public string BuyRate { get; set; } = "0.0000";

        [JsonPropertyOrder(19)]
        [JsonPropertyName("buyrateinitblock")]
        public string BuyRateInitBlock { get; set; } = "1";

        [JsonPropertyOrder(20)]
        [JsonPropertyName("buyrateincrement")]
        public string BuyRateIncrement { get; set; } = "1";

        [JsonPropertyOrder(21)]
        [JsonPropertyName("minimal_time_buy")]
        public string MinimalTimeBuy { get; set; } = "0";

        [JsonPropertyOrder(22)]
        [JsonPropertyName("minimal_time_charge")]
        public string MinimalTimeCharge { get; set; } = "0";

        [JsonPropertyOrder(23)]
        [JsonPropertyName("package_offer")]
        public string PackageOffer { get; set; } = "0";

        [JsonPropertyOrder(24)]
        [JsonPropertyName("status")]
        public string Status { get; set; } = "1";

        [JsonPropertyOrder(25)]
        [JsonPropertyName("lastuse")]
        public string LastUse { get; set; } = string.Empty;

        [JsonPropertyOrder(26)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}