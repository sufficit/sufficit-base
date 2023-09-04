using Sufficit.Telefonia;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<DirectInwardDialing>? DIDs { get; set; }

        public IEnumerable<FilaEspera>? Queues { get; set; }

        public IEnumerable<EndPoint>? EndPoints { get; set; }

        /// <summary>
        ///     Old menus (URA)
        /// </summary>
        public IEnumerable<URA>? URAs { get; set; }

        /// <summary>
        ///     New Menus (IVR)
        /// </summary>
        public IEnumerable<IVR>? IVRs { get; set; }

        public IEnumerable<DestinoPersonalizado>? Customs { get; set; }

        public IEnumerable<FollowMe>? FollowMe { get; set; }

        public IEnumerable<CondicaoTempo>? TimeConditions { get; set; }

        public IEnumerable<WebCallBack>? WebCallBacks { get; set; }

        public IEnumerable<Enquete>? Pools { get; set; }

        /// <summary>
        ///     PHONEVOX Integrations 
        /// </summary>
        public IEnumerable<AGIScript>? Scripts { get; set; }

        public IEnumerable<Sufficit.Telefonia.Audio>? Audios { get; set; }

        public IEnumerable<Sufficit.Telefonia.Anuncio>? Announcements { get; set; }

        public IEnumerable<Sufficit.Telefonia.Extensao>? MailBoxes { get; set; }

        public IEnumerable<BillingCost>? BillingCosts { get; set; }

        public Balance? BillingBalance { get; set; }
    }    
}
