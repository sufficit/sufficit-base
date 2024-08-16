using Sufficit.Gateway.PhoneVox;
using Sufficit.Gateway.ReceitaNet;
using Sufficit.Telefonia;
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
        ///     Old menus (URA)
        /// </summary>
        [JsonPropertyName("uras")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<URA>? URAs { get; set; }

        /// <summary>
        ///     New Menus (IVR)
        /// </summary>
        [JsonPropertyName("ivrs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<IVR>? IVRs { get; set; }

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

        [JsonPropertyName("pools")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Enquete>? Pools { get; set; }

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
        public IEnumerable<Sufficit.Telefonia.Extensao>? MailBoxes { get; set; }

        [JsonPropertyName("billingcosts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<BillingCost>? BillingCosts { get; set; }

        [JsonPropertyName("billingbalance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Balance? BillingBalance { get; set; }

        [JsonPropertyName("oldones")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public object? PurgeReport { get; set; }
    }    
}
