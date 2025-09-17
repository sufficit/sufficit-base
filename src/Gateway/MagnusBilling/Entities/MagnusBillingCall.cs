using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling Call entity compatible with pkg_call table
    /// Represents call detail records in MagnusBilling system
    /// </summary>
    public class MagnusBillingCall
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyOrder(2)]
        [JsonPropertyName("id_user")]
        public string IdUser { get; set; } = string.Empty;

        [JsonPropertyOrder(3)]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyOrder(4)]
        [JsonPropertyName("calledstation")]
        public string CalledStation { get; set; } = string.Empty;

        [JsonPropertyOrder(5)]
        [JsonPropertyName("callingstation")]
        public string CallingStation { get; set; } = string.Empty;

        [JsonPropertyOrder(6)]
        [JsonPropertyName("starttime")]
        public string StartTime { get; set; } = string.Empty;

        [JsonPropertyOrder(7)]
        [JsonPropertyName("stoptime")]
        public string StopTime { get; set; } = string.Empty;

        [JsonPropertyOrder(8)]
        [JsonPropertyName("sessiontime")]
        public string SessionTime { get; set; } = "0";

        [JsonPropertyOrder(9)]
        [JsonPropertyName("real_sessiontime")]
        public string RealSessionTime { get; set; } = "0";

        [JsonPropertyOrder(10)]
        [JsonPropertyName("terminatecauseid")]
        public string TerminateCauseId { get; set; } = "0";

        [JsonPropertyOrder(11)]
        [JsonPropertyName("cost")]
        public string Cost { get; set; } = "0.0000";

        [JsonPropertyOrder(12)]
        [JsonPropertyName("price")]
        public string Price { get; set; } = "0.0000";

        [JsonPropertyOrder(13)]
        [JsonPropertyName("id_plan")]
        public string IdPlan { get; set; } = string.Empty;

        [JsonPropertyOrder(14)]
        [JsonPropertyName("id_rate")]
        public string IdRate { get; set; } = string.Empty;

        [JsonPropertyOrder(15)]
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; } = string.Empty;

        [JsonPropertyOrder(16)]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyOrder(17)]
        [JsonPropertyName("id_trunk")]
        public string IdTrunk { get; set; } = string.Empty;

        [JsonPropertyOrder(18)]
        [JsonPropertyName("id_did")]
        public string IdDid { get; set; } = string.Empty;

        [JsonPropertyOrder(19)]
        [JsonPropertyName("buyrate")]
        public string BuyRate { get; set; } = "0.0000";

        [JsonPropertyOrder(20)]
        [JsonPropertyName("buycost")]
        public string BuyCost { get; set; } = "0.0000";

        [JsonPropertyOrder(21)]
        [JsonPropertyName("id_provider")]
        public string IdProvider { get; set; } = string.Empty;

        [JsonPropertyOrder(22)]
        [JsonPropertyName("calltype")]
        public string CallType { get; set; } = "0";

        [JsonPropertyOrder(23)]
        [JsonPropertyName("sipiax")]
        public string SipIax { get; set; } = "0";

        [JsonPropertyOrder(24)]
        [JsonPropertyName("id_sip")]
        public string IdSip { get; set; } = string.Empty;

        [JsonPropertyOrder(25)]
        [JsonPropertyName("callerid")]
        public string CallerId { get; set; } = string.Empty;

        [JsonPropertyOrder(26)]
        [JsonPropertyName("uniqueid")]
        public string UniqueId { get; set; } = string.Empty;

        [JsonPropertyOrder(27)]
        [JsonPropertyName("accountcode")]
        public string AccountCode { get; set; } = string.Empty;

        [JsonPropertyOrder(28)]
        [JsonPropertyName("userfield")]
        public string UserField { get; set; } = string.Empty;

        [JsonPropertyOrder(29)]
        [JsonPropertyName("did")]
        public string Did { get; set; } = string.Empty;

        [JsonPropertyOrder(30)]
        [JsonPropertyName("agent_bill")]
        public string AgentBill { get; set; } = "0";

        [JsonPropertyOrder(31)]
        [JsonPropertyName("id_reseller")]
        public string IdReseller { get; set; } = string.Empty;

        [JsonPropertyOrder(32)]
        [JsonPropertyName("markup")]
        public string Markup { get; set; } = "0.0000";

        [JsonPropertyOrder(33)]
        [JsonPropertyName("id_server")]
        public string IdServer { get; set; } = "1";

        [JsonPropertyOrder(34)]
        [JsonPropertyName("server_ip")]
        public string ServerIp { get; set; } = string.Empty;

        [JsonPropertyOrder(35)]
        [JsonPropertyName("dnid")]
        public string Dnid { get; set; } = string.Empty;

        [JsonPropertyOrder(36)]
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyOrder(37)]
        [JsonPropertyName("dstchannel")]
        public string DstChannel { get; set; } = string.Empty;

        [JsonPropertyOrder(38)]
        [JsonPropertyName("lastapp")]
        public string LastApp { get; set; } = string.Empty;

        [JsonPropertyOrder(39)]
        [JsonPropertyName("lastdata")]
        public string LastData { get; set; } = string.Empty;

        [JsonPropertyOrder(40)]
        [JsonPropertyName("amaflags")]
        public string AmaFlags { get; set; } = "0";

        [JsonPropertyOrder(41)]
        [JsonPropertyName("disposition")]
        public string Disposition { get; set; } = string.Empty;

        [JsonPropertyOrder(42)]
        [JsonPropertyName("trunk")]
        public string Trunk { get; set; } = string.Empty;
    }
}