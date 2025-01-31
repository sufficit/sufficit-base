using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Audio
{
    public class AudioMixSaveRequest
    {
        public Guid ContextId { get; set; }

        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; } = default!;
    }
}
