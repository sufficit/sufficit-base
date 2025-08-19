using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PhoneVox
{
    public class PhoneVoxGateway : PhoneVoxOptions, IDestination, IFriendly
    {
        public const string TAG = "phonevox";
        public const string ASTERISKCONTEXT = "sufficit-gateway-" + TAG;
        public const string FRIENDLYNAME = "Gateway PhoneVox";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => Id;

        string IDestination.TypeName => nameof(PhoneVoxGateway);

        Guid? IDestination.ContextId => ContextId;

        string IDestination.Asterisk => $"{ASTERISKCONTEXT},{Id:N},1";

        string? IDestination.Title => Server.Title ?? $"PhoneVox - {Id:N}";

        string? IDestination.Description => App;

        #endregion

        [JsonPropertyName("destinations")]
        [JsonPropertyOrder(2)]
        public virtual ICollection<PhoneVoxDestination> Destinations { get; set; }
            = new HashSet<PhoneVoxDestination>();
    }
}
