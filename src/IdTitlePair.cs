using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    public class IdTitlePair : IIdTitlePair
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
    }
}
