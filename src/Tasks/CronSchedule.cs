using System.ComponentModel.DataAnnotations;

namespace Sufficit.Tasks
{
    /// <summary>
    /// Defines the five persisted fields of a UTC cron-like schedule.
    /// A null or empty field means every valid value for that field.
    /// Values are stored as comma-separated, zero-padded two-digit numbers.
    /// </summary>
    public class CronSchedule
    {
        /// <summary>
        /// Minutes between <c>00</c> and <c>59</c>.
        /// </summary>
        [StringLength(50)]
        public string? Minutes { get; set; }

        /// <summary>
        /// Hours between <c>00</c> and <c>23</c>.
        /// </summary>
        [StringLength(50)]
        public string? Hours { get; set; }

        /// <summary>
        /// Days of the month between <c>01</c> and <c>31</c>.
        /// </summary>
        [StringLength(50)]
        public string? MonthDays { get; set; }

        /// <summary>
        /// Months between <c>01</c> and <c>12</c>.
        /// </summary>
        [StringLength(50)]
        public string? Months { get; set; }

        /// <summary>
        /// Days of the week between <c>00</c> (Sunday) and <c>06</c> (Saturday).
        /// </summary>
        [StringLength(50)]
        public string? WeekDays { get; set; }
    }
}
