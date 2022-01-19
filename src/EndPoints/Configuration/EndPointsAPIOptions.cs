using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.EndPoints.Configuration
{
    public class EndPointsAPIOptions
    {
        public const string SectionName = "Sufficit:EndPoints";

        public string BaseUrl { get; set; }

        public string ClientId { get; set; }

        public bool WebSocketAuto { get; set; } = true;
    }
}
