using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit
{
    [Flags]
    public enum ExportMethod
    {
        /// <summary>
        ///     Default Export Method (.json, application/json)
        /// </summary>
        [EnumMember(Value = "json")]
        JSON = 0,

        /// <summary>
        ///     Export Method for Excel (.xlsx, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet)
        /// </summary>
        [EnumMember(Value = "spreadsheet")]
        SPREADSHEET = 1,

        /// <summary>
        ///     Export Method for PDF (.pdf, application/pdf)
        /// </summary>
        [EnumMember(Value = "pdf")]
        PDF = 2,
    }
}
