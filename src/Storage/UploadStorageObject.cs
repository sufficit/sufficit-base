using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Storage
{
    public class UploadStorageObject : StorageObject
    {
        public bool Success { get; set; }

        public Exception? Exception { get; set; }

        public override bool Equals(object? obj)
            => obj is UploadStorageObject other             
            && other.Success.Equals(Success)
            && other.Exception == Exception
            && base.Equals(other);

        public override int GetHashCode()
            => (Success, Exception).GetHashCode() ^ base.GetHashCode();
    }
}
