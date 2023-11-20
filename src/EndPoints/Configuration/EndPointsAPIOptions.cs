using System;
using System.Collections.Generic;
using System.Text;
using static Sufficit.EndPoints.Constants;

namespace Sufficit.EndPoints.Configuration
{
    public class EndPointsAPIOptions
    {
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(EndPoints);

        public string BaseUrl { get; set; } = SERVERURL;

        public string ClientId { get; set; } = "SufficitEndPoints";

        public bool WebSocketAuto { get; set; } = false;

        /// <summary>
        /// Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        public uint? TimeOut { get; set; } 
    }
}
