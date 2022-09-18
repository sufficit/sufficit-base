using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public interface ICallRecordingProvider
    {
        public string? Title { get; }

        public Task<LoadedFile?> Download(string path, CancellationToken cancellationToken);
    }
}
