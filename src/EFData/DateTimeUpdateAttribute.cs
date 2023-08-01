using System;
using System.Linq;
using System.Reflection;

namespace Sufficit
{
    /// <summary>
    ///     Set the current datetime when saving data
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DateTimeUpdateAttribute : Attribute
    {
        public DateTimeUpdateAttribute(bool useUtc = true, bool onInsert = true, bool onUpdate = true)
        {
            OnInsert = onInsert;
            OnUpdate = onUpdate;
            UseUTC = useUtc;
        }

        public bool OnInsert { get; }

        public bool OnUpdate { get; }

        public bool UseUTC { get; }
    }
}
