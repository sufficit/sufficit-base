using Sufficit.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static Sufficit.EndPoints.Constants;

namespace Sufficit.EndPoints.Configuration
{
    public class EndPointsAPIOptions : IHttpClientOptions
    {
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(EndPoints);

        public string BaseAddress { get; set; } = SERVERURL;

        public string? BaseUrl { get => BaseAddress; set => BaseAddress = value ?? string.Empty; }

        public string? UserAgent { get; set; } = "C# API Client";

        public bool WebSocketAuto { get; set; } = false;

        /// <summary>
        /// Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        public uint? TimeOut { get; set; } 
    }
}
