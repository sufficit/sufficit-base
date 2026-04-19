using Sufficit.Gateway.PhoneVox;
using Sufficit.Gateway.ReceitaNet;
using Sufficit.Telefonia;
using Sufficit.Telephony.IVR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     All client informations and objects
    /// </summary>
    public class Organization
    {
        public Organization(Guid contextid) 
        { 
            ContextId = contextid;
        }

        public Guid ContextId { get; }

        public ContextMapping? Mapping { get; set; }

        [JsonPropertyName("dids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<DirectInwardDialing>? DIDs { get; set; }

        [JsonPropertyName("queues")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<FilaEspera>? Queues { get; set; }

        [JsonPropertyName("endpoints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<EndPoint>? EndPoints { get; set; }

        [JsonPropertyName("endpointproperties")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<EndPointProperty>? EndPointProperties { get; set; }

        /// <summary>
        ///     Provisioning devices
        /// </summary>
        [JsonPropertyName("devices")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Device>? Devices { get; set; }

        /// <summary>
        ///     New Menus (IVR)
        /// </summary>
        [JsonPropertyName("ivrs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<IVRMenu>? IVRs { get; set; }

        [JsonPropertyName("musiconhold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<MusicOnHoldInfo>? MusicOnHold { get; set; }

        [JsonPropertyName("customs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<DestinoPersonalizado>? Customs { get; set; }

        [JsonPropertyName("followme")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<FollowMe>? FollowMe { get; set; }

        [JsonPropertyName("timeconditions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<CondicaoTempo>? TimeConditions { get; set; }

        [JsonPropertyName("webcallback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public WebCallBack? WebCallBack { get; set; }

        /// <summary>
        ///     PHONEVOX Integrations 
        /// </summary>
        [JsonPropertyName("gateway.scripts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<AGIScript>? Scripts { get; set; }

        /// <summary>
        ///     PHONEVOX Integrations (new)
        /// </summary>
        [JsonPropertyName("gateway.phonevox")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<PhoneVoxOptions>? PhoneVoxOptions { get; set; }

        /// <summary>
        ///     RECEITANET Integrations
        /// </summary>
        [JsonPropertyName("gateway.receitanet")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<RNOptions>? ReceitaNetOptions { get; set; }

        [JsonPropertyName("audios")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Sufficit.Telefonia.Audio>? Audios { get; set; }

        [JsonPropertyName("announcements")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Sufficit.Telefonia.Anuncio>? Announcements { get; set; }

        [JsonPropertyName("mailboxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<VoiceMailBox>? MailBoxes { get; set; }

        [JsonPropertyName("billingcosts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<BillingCost>? BillingCosts { get; set; }

        [JsonPropertyName("billingbalance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Balance? BillingBalance { get; set; }

        [JsonPropertyName("oldones")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public LegacyPurgeSummary? LegacyPurgePreview { get; set; }
    }    

    public class LegacyPurgeSummary
    {
        public DateTime CreationTime { get; } = DateTime.Now;

        public bool Test { get; set; }

        public Guid IDContexto { get; set; }

        public int DIDs { get; set; }

        public int Queues { get; set; }

        public int IVRs { get; set; }

        public int CustomApps { get; set; }

        public int Extensions { get; set; }

        public int FollowMe { get; set; }

        public int TimeConditions { get; set; }

        public int WebCallBacks { get; set; }

        public int Integrations { get; set; }

        public int Audios { get; set; }

        public int Announcements { get; set; }

        public int MailBoxes { get; set; }

        public int BillingCosts { get; set; }

        public int BillingBalance { get; set; }

        public int Mapping { get; set; }

        public int PendingTotal => DIDs
            + Queues
            + IVRs
            + CustomApps
            + Extensions
            + FollowMe
            + TimeConditions
            + WebCallBacks
            + Integrations
            + Audios
            + Announcements
            + MailBoxes
            + BillingCosts
            + BillingBalance
            + Mapping;
    }
}
