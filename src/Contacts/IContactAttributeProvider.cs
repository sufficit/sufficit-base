using System.Collections.Generic;
using System.Threading;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Provider-neutral stream of contact attributes used by application runtimes.
    /// </summary>
    public interface IContactAttributeProvider
    {
        IAsyncEnumerable<ContactAttribute> GetAttributes(
            AttributeSearchParameters parameters,
            CancellationToken cancellationToken);
    }
}
