using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Sufficit.Telephony;

namespace Sufficit.Gateway.ElevenLabs
{
    public static class ElevenLabsExtensions
    {
        public static ElevenLabsGateway ToGateway (this DirectInwardDialing source)
        {
            return new ElevenLabsGateway(source.Extension)
            {
                 //Id = source.Id,
                 ContextId = source.ContextId,
            };
        }
    }
}
