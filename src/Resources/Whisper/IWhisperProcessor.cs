using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Sufficit.Resources.Whisper
{
    public interface IWhisperProcessor : IAsyncDisposable
    {
        IAsyncEnumerable<WhisperSegment> ProcessAsync(Stream waveStream, CancellationToken cancellationToken);
    }
}
