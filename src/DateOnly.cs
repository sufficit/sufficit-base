#if NETSTANDARD2_0

using System;
using System.ComponentModel;
using System.Globalization;

namespace Sufficit
{
    /// <summary>
    /// DateOnly implementation for .NET Standard 2.0 compatibility
    /// Represents a date without time information
    /// </summary>
    [TypeConverter(typeof(DateOnlyTypeConverter))]
    public readonly struct DateOnly : IComparable<DateOnly>, IEquatable<DateOnly>, IFormattable
    {
        private readonly DateTime _value;

        /// <summary>
        /// Initializes a new instance of DateOnly with the specified year, month, and day
        /// </summary>
        public DateOnly(int year, int month, int day)
        {
            _value = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance of DateOnly from a DateTime (time portion is ignored)
        /// </summary>
        public DateOnly(DateTime dateTime)
        {
            _value = dateTime.Date;
        }

        /// <summary>
        /// Gets the year component of the date
        /// </summary>
        public int Year => _value.Year;

        /// <summary>
        /// Gets the month component of the date
        /// </summary>
        public int Month => _value.Month;

        /// <summary>
        /// Gets the day component of the date
        /// </summary>
        public int Day => _value.Day;

        /// <summary>
        /// Gets the day of the week
        /// </summary>
        public DayOfWeek DayOfWeek => _value.DayOfWeek;

        /// <summary>
        /// Gets the day of the year
        /// </summary>
        public int DayOfYear => _value.DayOfYear;

        /// <summary>
        /// Gets a DateOnly instance that represents today's date
        /// </summary>
        public static DateOnly Today => new DateOnly(DateTime.Today);

        /// <summary>
        /// Gets the minimum value of DateOnly
        /// </summary>
        public static DateOnly MinValue => new DateOnly(DateTime.MinValue);

        /// <summary>
        /// Gets the maximum value of DateOnly
        /// </summary>
        public static DateOnly MaxValue => new DateOnly(DateTime.MaxValue.Date);

        /// <summary>
        /// Converts DateOnly to DateTime at midnight
        /// </summary>
        public DateTime ToDateTime() => _value;

        /// <summary>
        /// Converts DateOnly to DateTime with specified time
        /// </summary>
        public DateTime ToDateTime(TimeSpan time) => _value.Add(time);

        /// <summary>
        /// Adds the specified number of days to this DateOnly
        /// </summary>
        public DateOnly AddDays(int days) => new DateOnly(_value.AddDays(days));

        /// <summary>
        /// Adds the specified number of months to this DateOnly
        /// </summary>
        public DateOnly AddMonths(int months) => new DateOnly(_value.AddMonths(months));

        /// <summary>
        /// Adds the specified number of years to this DateOnly
        /// </summary>
        public DateOnly AddYears(int years) => new DateOnly(_value.AddYears(years));

        /// <summary>
        /// Parses a string representation of a date to DateOnly
        /// </summary>
        public static DateOnly Parse(string s) => new DateOnly(DateTime.Parse(s));

        /// <summary>
        /// Tries to parse a string representation of a date to DateOnly
        /// </summary>
        public static bool TryParse(string? s, out DateOnly result)
        {
            if (DateTime.TryParse(s, out var dateTime))
            {
                result = new DateOnly(dateTime);
                return true;
            }
            result = default;
            return false;
        }

        /// <summary>
        /// Parses a string representation with specified format
        /// </summary>
        public static DateOnly ParseExact(string s, string format, IFormatProvider? provider = null)
        {
            return new DateOnly(DateTime.ParseExact(s, format, provider ?? CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Tries to parse a string representation with specified format
        /// </summary>
        public static bool TryParseExact(string? s, string format, IFormatProvider? provider, DateTimeStyles style, out DateOnly result)
        {
            if (DateTime.TryParseExact(s, format, provider, style, out var dateTime))
            {
                result = new DateOnly(dateTime);
                return true;
            }
            result = default;
            return false;
        }

        /// <summary>
        /// Creates DateOnly from DateTime
        /// </summary>
        public static DateOnly FromDateTime(DateTime dateTime) => new DateOnly(dateTime);

        #region IComparable<DateOnly> Implementation
        public int CompareTo(DateOnly other) => _value.CompareTo(other._value);
        #endregion

        #region IEquatable<DateOnly> Implementation
        public bool Equals(DateOnly other) => _value.Equals(other._value);
        public override bool Equals(object? obj) => obj is DateOnly other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        #endregion

        #region IFormattable Implementation
        public string ToString(string? format, IFormatProvider? formatProvider = null)
        {
            return _value.ToString(format ?? "yyyy-MM-dd", formatProvider ?? CultureInfo.InvariantCulture);
        }
        #endregion

        #region Operators
        public static bool operator ==(DateOnly left, DateOnly right) => left.Equals(right);
        public static bool operator !=(DateOnly left, DateOnly right) => !left.Equals(right);
        public static bool operator <(DateOnly left, DateOnly right) => left.CompareTo(right) < 0;
        public static bool operator <=(DateOnly left, DateOnly right) => left.CompareTo(right) <= 0;
        public static bool operator >(DateOnly left, DateOnly right) => left.CompareTo(right) > 0;
        public static bool operator >=(DateOnly left, DateOnly right) => left.CompareTo(right) >= 0;

        public static implicit operator DateTime(DateOnly dateOnly) => dateOnly._value;
        public static explicit operator DateOnly(DateTime dateTime) => new DateOnly(dateTime);
        #endregion

        public override string ToString() => ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Type converter for DateOnly
    /// </summary>
    public class DateOnlyTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string) || sourceType == typeof(DateTime) || base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string stringValue)
            {
                if (DateOnly.TryParse(stringValue, out var result))
                    return result;
            }
            else if (value is DateTime dateTime)
            {
                return new DateOnly(dateTime);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        {
            return destinationType == typeof(string) || destinationType == typeof(DateTime) || base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (value is DateOnly dateOnly)
            {
                if (destinationType == typeof(string))
                    return dateOnly.ToString();
                else if (destinationType == typeof(DateTime))
                    return dateOnly.ToDateTime();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

#endif
