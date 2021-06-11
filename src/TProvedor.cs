using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit
{
    /// <summary>
    /// Opção ainda sem utilização efetiva <br />
    /// Por padrão, todos são 0 = Aplicação
    /// </summary>
    public enum TProvedor
    {
        /// <summary>
        /// Tipo de provedor que permanecerá instanciado do início ao fim da aplicação
        /// </summary>
        Aplicacao = 0,

        /// <summary>
        /// Tipo de provedor que permanecerá instanciado durante uma seção específica
        /// </summary>
        Secao = 1,

        /// <summary>
        /// Tipo de provedor que permanecerá instanciado enquanto o usuário específico permanecer em atividade
        /// </summary>
        Usuario = 2
    }
}
