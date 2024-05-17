using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.EMail
{
    /// <summary>
    /// Basic information about open and reading emails sended by this system <br/>
    /// Common used with an jpg image tracking
    /// </summary>
    public class EMailTrackingInfo : IReadReceipt
    {
        public DateTime Timestamp { get; set; }
        public Guid Id { get; set; }
        public string? Source { get; set; }
        public string? Agent { get; set; }

        public string ToStringFormatted()
            => $"email id: {Id}, acessed at: {Timestamp.ToString("yyyy/MM/dd HH:mm:ss")}, agent: {Agent}, from: {Source}";

        string IReadReceipt.Description
            => $"acessed at: {Timestamp.ToString("yyyy/MM/dd HH:mm:ss")}, agent: {Agent}, from: {Source}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
            => obj is EMailTrackingInfo p && 
            (p.Timestamp - Timestamp).Duration() < TimeSpan.FromMinutes(1) && // rounding by 1 minute difference
            p.Id == Id && 
            p.Source == Source && 
            p.Agent == Agent;

        public override int GetHashCode()
            => (Timestamp, Id, Source, Agent).GetHashCode();
    }
}
