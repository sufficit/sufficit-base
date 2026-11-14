using System;
using System.Collections.Generic;

namespace Sufficit.Support
{
    /// <summary>
    /// A two-way support conversation between a customer context and Sufficit: issues, improvement requests,
    /// questions or requests that Sufficit sends to the customer. Generic: any software (an AI using a Sufficit skill,
    /// Fleet, a panel) can open and answer threads.
    /// </summary>
    public sealed class SupportThread
    {
        /// <summary>Server-generated identifier.</summary>
        public Guid Id { get; set; }
        /// <summary>Customer context that owns the thread; Sufficit sees every context.</summary>
        public Guid ContextId { get; set; }
        /// <summary>One of <see cref="SupportThreadKinds"/>.</summary>
        public string Kind { get; set; } = SupportThreadKinds.Issue;
        /// <summary>Short title.</summary>
        public string Subject { get; set; } = string.Empty;
        /// <summary>Optional software or skill the thread is about, e.g. <c>skill:sufficit-voice-agents</c> or <c>fleet</c>.</summary>
        public string? Source { get; set; }
        /// <summary>Optional opaque reference inside the source (agent id, call id, version).</summary>
        public string? Reference { get; set; }
        /// <summary>Side that opened the thread, one of <see cref="SupportSides"/>.</summary>
        public string OpenedBy { get; set; } = SupportSides.Customer;
        /// <summary>Side of the latest message; an open thread waits for the other side.</summary>
        public string LastSide { get; set; } = SupportSides.Customer;
        /// <summary>One of <see cref="SupportThreadStates"/>.</summary>
        public string State { get; set; } = SupportThreadStates.Open;
        /// <summary>Number of messages.</summary>
        public int Messages { get; set; }
        /// <summary>Monotonic revision, raised by every change.</summary>
        public long Revision { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }

        /// <summary>Side expected to act next; null when closed.</summary>
        public string? WaitingFor => State == SupportThreadStates.Closed ? null : SupportSides.Other(LastSide);
    }

    /// <summary>One message of a thread. Messages are immutable.</summary>
    public sealed class SupportMessage
    {
        public Guid Id { get; set; }
        public Guid ThreadId { get; set; }
        public Guid ContextId { get; set; }
        /// <summary>Client-generated idempotency key: a retry with the same key returns the original message.</summary>
        public Guid RequestId { get; set; }
        /// <summary>One of <see cref="SupportSides"/>.</summary>
        public string Side { get; set; } = SupportSides.Customer;
        /// <summary>Authenticated author (user or system user); never supplied by the client.</summary>
        public Guid AuthorId { get; set; }
        /// <summary>Plain text; never credentials or personal data beyond what the request needs.</summary>
        public string Body { get; set; } = string.Empty;
        /// <summary>Change this message made to the thread: <c>message</c>, <c>closed</c> or <c>reopened</c>.</summary>
        public string Change { get; set; } = SupportChanges.Message;
        public DateTime CreatedAtUtc { get; set; }
    }

    /// <summary>A thread with its messages, oldest first.</summary>
    public sealed class SupportThreadDetail
    {
        public SupportThread Thread { get; set; } = new SupportThread();
        public IList<SupportMessage> Messages { get; set; } = new List<SupportMessage>();
    }

    public static class SupportThreadKinds
    {
        public const string Issue = "issue", Improvement = "improvement", Question = "question", Request = "request";
        public static readonly string[] All = { Issue, Improvement, Question, Request };
    }

    public static class SupportSides
    {
        public const string Customer = "customer", Sufficit = "sufficit";
        public static string Other(string side) => side == Sufficit ? Customer : Sufficit;
    }

    public static class SupportThreadStates
    {
        public const string Open = "open", Closed = "closed";
    }

    public static class SupportChanges
    {
        public const string Opened = "opened", Message = "message", Closed = "closed", Reopened = "reopened";
    }
}
