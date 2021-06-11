using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Notification
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; } = DateTime.UtcNow;
        public abstract Guid ID { get; }
        public abstract string Title { get; }

        /// <summary>
        /// Chave de inscrição no evento, não sei ainda se será obrigatório
        /// </summary>
        /// <returns></returns>
        public virtual string GetKey() { throw new NotImplementedException(); }

        /// <summary>
        /// Metodo para gerar o texto básico desta notificação
        /// </summary>
        /// <returns></returns>
        public virtual Task<string> GetBody(string extra = default, TChannel channel = default) {
            return Task.FromResult($"Evento: { Title }, acionado as { TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK") }");
        }

        /// <summary>
        /// Tentativa de dispachar este evento de alguma forma
        /// </summary>
        public virtual Task<bool> TryDispatch()
        {
            throw new NotImplementedException();
        }
    }
}
