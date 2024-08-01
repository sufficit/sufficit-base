using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class TimeInterval
    {
        public const uint MAXTIME = 2359;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Range(0, MAXTIME)]
        public uint? HourStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Range(0, MAXTIME)]
        public uint? HourEnd { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 7)]
        public uint? WeekDayStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 7)]
        public uint? WeekDayEnd { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 31)]
        public uint? MonthDayStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 31)]
        public uint? MonthDayEnd { get; set ; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 12)]
        public uint? MonthStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, 12)]
        public uint? MonthEnd { get; set; }

        public override bool Equals(object? obj)
        => obj is TimeInterval other && 
            other.HourStart == HourStart && 
            other.HourEnd == HourEnd &&
            other.WeekDayStart == WeekDayStart &&
            other.WeekDayEnd == WeekDayEnd &&
            other.MonthDayStart == MonthDayStart &&
            other.MonthDayEnd == MonthDayEnd &&
            other.MonthStart == MonthStart &&
            other.MonthEnd == MonthEnd;

        public override int GetHashCode()
            => (HourStart, HourEnd, WeekDayStart, WeekDayEnd, MonthDayStart, MonthDayEnd, MonthStart, MonthEnd).GetHashCode();
    }
}
