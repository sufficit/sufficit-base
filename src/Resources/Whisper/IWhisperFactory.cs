using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Resources.Whisper
{
    public interface IWhisperFactory
    {
        ValueTask<IWhisperProcessor> GetProcessor(WhisperOptions options);
    }
}
