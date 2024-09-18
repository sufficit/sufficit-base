using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Sufficit
{
    public static class ExceptionExtensions
    {
        #region SYSTEM > EXCEPTION

        [Obsolete("try from Utils > ExceptionExtensions")]
        public static JsonException? ToJsonExceptionMoved(this System.Exception? source)
        {
            if (source == null) return null;

            var item = new JsonException();
            item.Type = source.GetType().ToString();
            item.InnerException = source.InnerException?.ToString();
            item.Message = source.Message;

            if (source.Data != null && source.Data.Count > 0)
                item.Data = source.Data; // used by receitanet

            return item;
        }

        #endregion
    }
}
