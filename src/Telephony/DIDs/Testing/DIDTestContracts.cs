using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.DIDs.Testing
{
    /// <summary>Lifecycle of one DID test, column <c>telp_did_test_runs.status</c>.</summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DIDTestRunStatus
    {
        /// <summary>Waiting for the worker, first call or retry.</summary>
        Pending,
        /// <summary>The worker claimed the run and started the call.</summary>
        Dialing,
        /// <summary>The test call reached our PBX: <see cref="DIDTestRun.ArrivalChannel"/> is the proof.</summary>
        Arrived,
        /// <summary>At least one call was placed and none reached our PBX.</summary>
        NotArrived,
        /// <summary>No conclusion about the DID: the test itself could not run, see <see cref="DIDTestRun.ErrorSummary"/>.</summary>
        Failed,
        /// <summary>Cancelled by an operator before dialing.</summary>
        Cancelled,
    }

    /// <summary>
    /// Caller id that places test calls, table <c>telp_did_test_origins</c>. Its number also feeds the PBX list that stops
    /// test calls, so it must be a DID of the Sufficit context: see <see cref="DIDTestRules"/>.
    /// </summary>
    public class DIDTestOrigin
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>Caller id, full E.164 digits without +.</summary>
        [JsonPropertyName("number")]
        public string Number { get; set; } = string.Empty;

        /// <summary>Asterisk SIP peer the call leaves through; null only while disabled.</summary>
        [JsonPropertyName("trunk")]
        public string? Trunk { get; set; }

        /// <summary>Digits the trunk requires before the dialed number.</summary>
        [JsonPropertyName("prefix")]
        public string? Prefix { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>Lower numbers are tried first.</summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; } = 100;

        [JsonPropertyName("createdatutc")]
        public DateTime CreatedAtUtc { get; set; }

        [JsonPropertyName("updatedatutc")]
        public DateTime? UpdatedAtUtc { get; set; }
    }

    /// <summary>Every parameter of the test system, single row of table <c>telp_did_test_settings</c>.</summary>
    public class DIDTestSettings
    {
        /// <summary>The only row of the table.</summary>
        public const byte SingleRowId = 1;

        [JsonIgnore]
        public byte Id { get; set; } = SingleRowId;

        /// <summary>Master switch: off keeps pending runs waiting and places no call.</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>Seconds a test call rings before giving up.</summary>
        [JsonPropertyName("ringseconds")]
        public int RingSeconds { get; set; } = 25;

        /// <summary>Calls per DID before concluding it did not arrive.</summary>
        [JsonPropertyName("attemptsperdid")]
        public int AttemptsPerDid { get; set; } = 2;

        /// <summary>Seconds between attempts on the same DID.</summary>
        [JsonPropertyName("retryseconds")]
        public int RetrySeconds { get; set; } = 60;

        /// <summary>Seconds between any two calls, so a batch does not flood the carrier.</summary>
        [JsonPropertyName("pacingseconds")]
        public int PacingSeconds { get; set; } = 20;

        /// <summary>Calls ringing at the same time.</summary>
        [JsonPropertyName("maxconcurrentcalls")]
        public int MaxConcurrentCalls { get; set; } = 1;

        /// <summary>Seconds after the ring time during which an arrival still counts.</summary>
        [JsonPropertyName("arrivalgraceseconds")]
        public int ArrivalGraceSeconds { get; set; } = 5;

        /// <summary>Seconds after the first call by which a run must conclude.</summary>
        [JsonPropertyName("runtimeoutseconds")]
        public int RunTimeoutSeconds { get; set; } = 600;

        /// <summary>Seconds between worker cycles.</summary>
        [JsonPropertyName("pollseconds")]
        public int PollSeconds { get; set; } = 5;

        /// <summary>Seconds between reconciliations of the caller id list on the PBX.</summary>
        [JsonPropertyName("syncseconds")]
        public int SyncSeconds { get; set; } = 30;

        /// <summary>Largest list accepted by one start request.</summary>
        [JsonPropertyName("maxbatchsize")]
        public int MaxBatchSize { get; set; } = 200;

        /// <summary>
        /// Only call DIDs present in the live registrations of the node that places the call. Those are known to land where
        /// the filter exists; any other DID could ring the customer while a PBX node lacks the filter.
        /// </summary>
        [JsonPropertyName("requireliveregistration")]
        public bool RequireLiveRegistration { get; set; } = true;

        /// <summary>Days finished runs are kept; execution audits live at most one month.</summary>
        [JsonPropertyName("runretentiondays")]
        public int RunRetentionDays { get; set; } = 30;

        [JsonPropertyName("updatedatutc")]
        public DateTime? UpdatedAtUtc { get; set; }

        /// <summary>User that last changed the settings.</summary>
        [JsonPropertyName("updatedby")]
        public Guid? UpdatedBy { get; set; }
    }

    /// <summary>One DID under test, table <c>telp_did_test_runs</c>.</summary>
    public class DIDTestRun
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>Number under test, full E.164 digits without +.</summary>
        [JsonPropertyName("did")]
        public string Did { get; set; } = string.Empty;

        /// <summary>Origin of the latest call.</summary>
        [JsonPropertyName("originid")]
        public Guid? OriginId { get; set; }

        /// <summary>Trunk of the latest call.</summary>
        [JsonPropertyName("trunk")]
        public string? Trunk { get; set; }

        /// <summary>Calls actually placed so far.</summary>
        [JsonPropertyName("attempt")]
        public int Attempt { get; set; }

        [JsonPropertyName("status")]
        public DIDTestRunStatus Status { get; set; } = DIDTestRunStatus.Pending;

        /// <summary>Inbound channel that proves the arrival.</summary>
        [JsonPropertyName("arrivalchannel")]
        public string? ArrivalChannel { get; set; }

        [JsonPropertyName("requestedby")]
        public Guid? RequestedBy { get; set; }

        [JsonPropertyName("requestedatutc")]
        public DateTime RequestedAtUtc { get; set; }

        /// <summary>First time the worker picked this run.</summary>
        [JsonPropertyName("startedatutc")]
        public DateTime? StartedAtUtc { get; set; }

        /// <summary>Latest call; the arrival window counts from here.</summary>
        [JsonPropertyName("lastdialedatutc")]
        public DateTime? LastDialedAtUtc { get; set; }

        /// <summary>Earliest moment of the next call while Pending; null means now.</summary>
        [JsonPropertyName("nextattemptatutc")]
        public DateTime? NextAttemptAtUtc { get; set; }

        [JsonPropertyName("finishedatutc")]
        public DateTime? FinishedAtUtc { get; set; }

        /// <summary>Numbers started together by one request.</summary>
        [JsonPropertyName("batchid")]
        public Guid BatchId { get; set; }

        /// <summary>Observed returns for requests made by instrumented workers; empty for older runs.</summary>
        [JsonPropertyName("returns")]
        public List<DIDTestAttempt> Returns { get; set; } = new List<DIDTestAttempt>();

        /// <summary>Why the test could not run: one code of <see cref="DIDTestErrors"/>, optionally followed by ": detail".</summary>
        [JsonPropertyName("errorsummary")]
        public string? ErrorSummary { get; set; }
    }

    /// <summary>Starts tests for one DID or a pasted list.</summary>
    public class DIDTestStartRequest
    {
        /// <summary>Numbers in any common format; see <see cref="DIDTestRules.ParseList"/>.</summary>
        [JsonPropertyName("dids")]
        public string Dids { get; set; } = string.Empty;
    }

    /// <summary>A pasted entry that did not become a test, and why.</summary>
    public class DIDTestRejectedNumber
    {
        [JsonPropertyName("input")]
        public string Input { get; set; } = string.Empty;

        /// <summary>One code of <see cref="DIDTestErrors"/>.</summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;
    }

    public class DIDTestStartResult
    {
        [JsonPropertyName("batchid")]
        public Guid BatchId { get; set; }

        [JsonPropertyName("runs")]
        public List<DIDTestRun> Runs { get; set; } = new List<DIDTestRun>();

        [JsonPropertyName("rejected")]
        public List<DIDTestRejectedNumber> Rejected { get; set; } = new List<DIDTestRejectedNumber>();
    }

    /// <summary>Filters of the run history; every one is optional.</summary>
    public class DIDTestRunSearchParameters
    {
        [JsonPropertyName("did")]
        public string? Did { get; set; }

        [JsonPropertyName("status")]
        public DIDTestRunStatus? Status { get; set; }

        [JsonPropertyName("batchid")]
        public Guid? BatchId { get; set; }

        [JsonPropertyName("start")]
        public DateTime? Start { get; set; }

        [JsonPropertyName("end")]
        public DateTime? End { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 200;
    }

    /// <summary>Codes stored in <see cref="DIDTestRun.ErrorSummary"/> and <see cref="DIDTestRejectedNumber.Reason"/>; screens translate them.</summary>
    public static class DIDTestErrors
    {
        public const string InvalidNumber = "invalid_number";
        public const string AlreadyActive = "already_active";
        public const string BatchLimit = "batch_limit";
        public const string NoOrigin = "no_origin";
        public const string OriginNotOnPbx = "origin_not_on_pbx";
        public const string NotRegistered = "not_registered";
        public const string RegistryUnavailable = "registry_unavailable";
        public const string OriginateFailed = "originate_failed";
        public const string TimedOutBeforeDialing = "timed_out_before_dialing";
    }
}
