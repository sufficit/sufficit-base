using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Contacts
{
    public interface IAttribute
    {
        string Key { get; }

        string? Value { get; }

        string Description { get; }
    }
}
