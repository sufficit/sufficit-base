using Sufficit.Telephony;
using Sufficit.Telephony.Asterisk;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ElevenLabs
{
    public class ElevenLabsGateway : AsteriskDestination, IDestination, IFriendly
    {
        public const string TAG = "elevenlabs";
        public const string ASTERISKCONTEXT = "sufficit-gateway-" + TAG;
        public const string FRIENDLYNAME = "Gateway ElevenLabs";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => null;

        string IDestination.TypeName => nameof(ElevenLabsGateway);

        Guid? IDestination.ContextId => ContextId;

        string IDestination.Asterisk => base.ToString();

        string? IDestination.Title => $"ElevenLabs - {Extension}";

        string? IDestination.Description => "Direct flow through ElevenLabs Gateway";

        #endregion

        public override string? Context => ASTERISKCONTEXT;

        public override string Priority => "1";

        public ElevenLabsGateway(string extension) : base(null)
        {
            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentNullException(nameof(extension), "Extension cannot be null or empty.");

            Extension = extension;
        }

        public Guid ContextId { get; set; }
    }
}
