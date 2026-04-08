using System;
using System.Collections.Generic;

namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Aggregated report for a full ReceitaNet compatibility run.
    /// </summary>
    public class ReceitaNetCompatibilityTestReport
    {
        /// <summary>
        /// Optional saved gateway identifier used for the run.
        /// </summary>
        public Guid? GatewayId { get; set; }

        /// <summary>
        /// Token used for the compatibility run.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether mutating operations were explicitly enabled.
        /// </summary>
        public bool AllowSideEffects { get; set; }

        /// <summary>
        /// Indicates whether every executed operation was compatible.
        /// </summary>
        public bool Compatible { get; set; }

        /// <summary>
        /// Detailed results for each compatibility operation.
        /// </summary>
        public List<ReceitaNetCompatibilityTestResult> Results { get; set; } = new List<ReceitaNetCompatibilityTestResult>();
    }
}