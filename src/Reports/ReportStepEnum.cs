using System.Runtime.Serialization;

namespace Sufficit.Reports
{
    public enum ReportStepEnum
    {
        [EnumMember(Value = "unknown")]
        UNKNOWN,

        /// <summary>
        ///     Parameters accepted, report wait schedule for start
        /// </summary>
        [EnumMember(Value = "accepted")]
        ACCEPTED = 1,

        /// <summary>
        ///    Report started, execution triggered
        /// </summary>
        [EnumMember(Value = "started")]
        STARTED = 10,

        /// <summary>
        ///     Fetching data from source (database)
        /// </summary>
        [EnumMember(Value = "fetching")]
        FETCHING = 20,

        [EnumMember(Value = "consoliding")]
        CONSOLIDING = 30,

        /// <summary>
        ///     Discarding invalid or not wanted data
        /// </summary>
        [EnumMember(Value = "filtering")]
        FILTERING = 40,

        /// <summary>
        ///    Processing the data
        /// </summary>
        [EnumMember(Value = "processing")]
        PROCESSING = 50,

        /// <summary>
        ///     Finishing the result formatting
        /// </summary>
        [EnumMember(Value = "formatting")]
        FORMATTING = 90,


        [EnumMember(Value = "finished")]
        FINISHED = 100,

        [EnumMember(Value = "error")]
        ERROR
    }
}
