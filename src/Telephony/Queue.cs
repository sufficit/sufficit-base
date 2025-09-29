using System;
using System.Collections.Generic;

namespace Sufficit.Telephony
{
    /// <summary>
    /// Agent status enumeration for queue monitoring
    /// </summary>
    public enum AgentStatus
    {
        Unknown,
        Available,
        Busy,
        InCall,
        LoggedOut,
        Ringing
    }

    /// <summary>
    /// Information about a queue agent
    /// </summary>
    public class QueueAgentInfo
    {
        public QueueAgentInfo(string iface)
        {
            Interface = iface;
        }

        /// <summary>
        /// Dial interface = Queue agent key
        /// </summary>
        public string Interface { get; }

        /// <summary>
        /// Agent type (static or dynamic)
        /// </summary>
        public string? Membership { get; set; }

        public string? Name { get; set; }
        public uint Penalty { get; set; }
        public uint CallsTaken { get; set; }
        public double LastCall { get; set; }
        public string Status { get; set; } = "Unknown";
        public bool Paused { get; set; }
        public bool InCall { get; set; }
        public string? PausedReason { get; set; }
        public int LastPause { get; set; }
        public int WrapUpTime { get; set; }

        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime Updated { get; set; }
    }

    /// <summary>
    /// Information about a call queue
    /// </summary>
    public class QueueInfo
    {
        public QueueInfo(string key)
        {
            Key = key;
            Agents = new List<QueueAgentInfo>();
        }

        /// <summary>
        /// Unique queue identifier
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Collection of agents in this queue
        /// </summary>
        public List<QueueAgentInfo> Agents { get; }

        public string? Strategy { get; set; }
        public int Max { get; set; }
        public int Calls { get; set; }
        public int HoldTime { get; set; }
        public int Completed { get; set; }
        public int Abandoned { get; set; }
        public int ServiceLevel { get; set; }
        public float ServiceLevelPerf { get; set; }
        public int Weight { get; set; }
        public int TalkTime { get; set; }

        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime Updated { get; set; }
    }
}