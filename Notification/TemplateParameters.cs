using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class TemplateParameters
    {
        /// <summary>
        /// Titulo da página que será exibido no e-mail
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Mensagem de observação
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Mensagem a ser exibida
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Resumo do texto para pre-visualização
        /// </summary>
        public string Preview { get; set; }

        /// <summary>
        /// Ação a ser realizada com o botão
        /// </summary>
        public string ActionText { get; set; }

        /// <summary>
        /// Link da Ação a ser realizada
        /// </summary>
        public string ActionLink { get; set; }

        public string UnsubscribeLink { get; set; }

        /// <summary>
        /// Caso verdadeiro, as variaveis não serão substituidas e retornara o template padrão
        /// </summary>
        public bool Test { get; set; }
    }
}
