using System;
using System.Linq;

namespace Sufficit.Support
{
    /// <summary>Opens a thread with its first message.</summary>
    public sealed class SupportThreadOpenRequest
    {
        /// <summary>Client-generated idempotency key; a retry returns the thread created by the first call.</summary>
        public Guid RequestId { get; set; }
        public Guid ContextId { get; set; }
        public string Kind { get; set; } = SupportThreadKinds.Issue;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string? Source { get; set; }
        public string? Reference { get; set; }
    }

    /// <summary>Adds a message; optionally closes or reopens the thread with it.</summary>
    public sealed class SupportMessageRequest
    {
        public Guid RequestId { get; set; }
        public string Body { get; set; } = string.Empty;
        /// <summary>Null keeps the state; <c>closed</c> closes; <c>open</c> reopens a closed thread.</summary>
        public string? State { get; set; }
        /// <summary>Optional optimistic check against <see cref="SupportThread.Revision"/>.</summary>
        public long? ExpectedRevision { get; set; }
    }

    /// <summary>Bounded thread query. A customer always queries one context.</summary>
    public sealed class SupportThreadSearch
    {
        public Guid? ContextId { get; set; }
        /// <summary><c>open</c>, <c>closed</c> or null for both.</summary>
        public string? State { get; set; }
        /// <summary>Only open threads waiting for this side.</summary>
        public string? WaitingFor { get; set; }
        /// <summary>Threads updated after this instant (UTC), for incremental polling.</summary>
        public DateTime? UpdatedAfterUtc { get; set; }
        public int Limit { get; set; } = 50;
    }

    /// <summary>Validation shared by every store and API.</summary>
    public static class SupportRules
    {
        public const int SubjectMax = 200, BodyMax = 8000, SourceMax = 100, ReferenceMax = 200, LimitMax = 200;

        public static void Validate(SupportThreadOpenRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.RequestId == Guid.Empty) throw new ArgumentException("requestId is required");
            if (request.ContextId == Guid.Empty) throw new ArgumentException("contextId is required");
            if (!SupportThreadKinds.All.Contains(request.Kind)) throw new ArgumentException("invalid kind");
            Text(request.Subject, SubjectMax, "subject");
            Text(request.Body, BodyMax, "body");
            if (request.Source?.Length > SourceMax) throw new ArgumentException("source too long");
            if (request.Reference?.Length > ReferenceMax) throw new ArgumentException("reference too long");
        }

        public static void Validate(SupportMessageRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.RequestId == Guid.Empty) throw new ArgumentException("requestId is required");
            Text(request.Body, BodyMax, "body");
            if (request.State != null && request.State != SupportThreadStates.Open && request.State != SupportThreadStates.Closed)
                throw new ArgumentException("invalid state");
        }

        public static void Validate(SupportThreadSearch search)
        {
            if (search == null) throw new ArgumentNullException(nameof(search));
            if (search.Limit < 1 || search.Limit > LimitMax) throw new ArgumentException("invalid limit");
            if (search.State != null && search.State != SupportThreadStates.Open && search.State != SupportThreadStates.Closed)
                throw new ArgumentException("invalid state");
            if (search.WaitingFor != null && search.WaitingFor != SupportSides.Customer && search.WaitingFor != SupportSides.Sufficit)
                throw new ArgumentException("invalid waitingFor");
        }

        private static void Text(string? value, int max, string name)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(name + " is required");
            if (value!.Length > max) throw new ArgumentException(name + " too long");
        }
    }

    /// <summary>The thread changed since the caller's expected revision.</summary>
    public sealed class SupportConflictException : Exception
    {
        public SupportConflictException(string message) : base(message) { }
    }
}
