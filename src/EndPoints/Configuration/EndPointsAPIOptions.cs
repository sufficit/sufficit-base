using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.EndPoints.Configuration
{
    public class EndPointsAPIOptions
    {
        public const string SECTIONNAME = "Sufficit:EndPoints";

        public string BaseUrl { get; set; } = "https://endpoints.sufficit.com.br";

        public string ClientId { get; set; } = "SufficitEndPoints";

        public bool WebSocketAuto { get; set; } = false;
    }
}
