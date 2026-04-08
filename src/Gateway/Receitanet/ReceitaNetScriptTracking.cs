using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Gateway.ReceitaNet
{
    public class ReceitaNetScriptTracking
    {
        public string Language { get; set; } = default!;

        public string HostName { get; set; } = default!;

        public string? CallerId { get; set; }

        public string? Phone { get; set; }

        public string? Document { get; set; }

        public Guid ChannelGatewayId { get; set; }

        public Guid FoundGatewayId { get; set; }

        public int? ContractId { get; set; }

        public string? ContractTitle { get; set; }

        public string? InitialIntent { get; set; }

        public string? FinalIntent { get; set; }

        public string? FinalDestination { get; set; }

        public string? FailureStep { get; set; }

        public string? FailureMessage { get; set; }

        public string? Outcome { get; set; }

        public List<string> Steps { get; set; } = new();

        public string? Exception { get; set; }
    }
}
