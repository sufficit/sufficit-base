using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// File content and information loaded in memory stream
    /// </summary>
    public class LoadedFile : MemoryStream
    {
        public DateTime? ModifiedAt { get; set; }
    }
}
