using System;

namespace Sufficit
{
    public class ProvedorEventoArgumentos : EventArgs
    {
        /// <summary>
        /// Objeto que esta passando pelo evento de alteração <br />
        /// Atualização, Inserção, Remoção
        /// </summary>
        public virtual object Item { get; set; }

        /// <summary>
        /// Indica se a operação foi concluída sem erros críticos
        /// </summary>
        public bool Sucesso { get; set; }

        /// <summary>
        /// Indica quantas tentativas foram executadas até a interrupção ou finalização do processo
        /// </summary>
        public int Tentativas { get; set; }

        /// <summary>
        /// Current user id that executed the action
        /// </summary>
        public Guid? UserId { get; set; }

        public ProvedorEventoArgumentos(object Item) : this(Item, false) { }
        public ProvedorEventoArgumentos(object Item, bool Sucesso) { this.Item = Item; this.Sucesso = Sucesso; }
    }
}
