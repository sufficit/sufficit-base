using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Resources.TTS
{
    public interface ITTSProvider
    {
        Task<TTSResponse> Process(TTSRequest request);
    }
}
