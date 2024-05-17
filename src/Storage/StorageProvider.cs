using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Storage
{
    public abstract class StorageProvider
    {
        /// <summary>
        ///     Retrieve content stream
        /// </summary>
        /// <param name="lock">Should lock the file until dispose stream ? If not, the file bytes is copied to a MemoryStream before returns, same as GetBytes.</param>
        /// <param name="fullpath"></param>
        /// <param name="cancellationToken"></param> 
        public abstract Task<Stream?> GetStream(string fullpath, bool @lock, CancellationToken cancellationToken);

        /// <summary>
        ///     Retrieve content bytes
        /// </summary>
        public abstract Task<byte[]?> GetBytes(string fullpath, CancellationToken cancellationToken);

        /// <summary>
        ///     Retrieve full object content and metadata if available
        /// </summary>
        public virtual Task<StorageObject?> GetObject(string fullpath, CancellationToken cancellationToken) { throw new NotImplementedException(); }

        public virtual Task Update(StorageObject @object, CancellationToken cancellationToken) { throw new NotImplementedException(); }

        public virtual Task Delete(string fullpath, CancellationToken cancellationToken) { throw new NotImplementedException(); }

        public virtual Task<StorageObjectMetadata?> GetMetadata(string fullpath, CancellationToken cancellationToken) { throw new NotImplementedException(); }

        public virtual IAsyncEnumerable<StorageObjectMetadata> GetIEnumerable(string fullpath, string pattern, SearchOption option, CancellationToken cancellationToken) { throw new NotImplementedException(); }

        public virtual IAsyncEnumerable<StorageObjectMetadata> GetIEnumerable(string fullpath, CancellationToken cancellationToken)
            => GetIEnumerable(fullpath, "*", SearchOption.TopDirectoryOnly, cancellationToken);
    }
}
