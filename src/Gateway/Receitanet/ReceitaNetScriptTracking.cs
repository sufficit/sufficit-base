using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Gateway.ReceitaNet
{
    public class ReceitaNetScriptTracking
    {
        public string Language { get; set; } = default!;

        public string? CallerId { get; set; }

        public Guid ChannelGatewayId { get; set; }

        public Guid FoundGatewayId { get; set; }

        public string? Exception { get; set; }
    }
}
