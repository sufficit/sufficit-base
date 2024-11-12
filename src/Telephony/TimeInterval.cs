using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    public class TimeInterval
    {
        public const string DEFAULTFREEPBX = "*|*|*|*";
        public const uint MAXTIME = 2359;
        public const uint MAXMONTH = 12;
        public const uint MAXMONTHDAY = 31;
        public const uint MAXWEEKDAY = 7;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Range(0, MAXTIME)]
        public uint? HourStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Range(0, MAXTIME)]
        public uint? HourEnd { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXWEEKDAY)]
        public uint? WeekDayStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXWEEKDAY)]
        public uint? WeekDayEnd { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXMONTHDAY)]
        public uint? MonthDayStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXMONTHDAY)]
        public uint? MonthDayEnd { get; set ; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXMONTH)]
        public uint? MonthStart { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]
        [Range(1, MAXMONTH)]
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
