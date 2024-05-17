using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Notification
{
    public class TemplateParameters
    {
        /// <summary>
        /// Titulo da página que será exibido no e-mail, tag html => head => title => %%%
        /// </summary>
        /// <remarks>*not all apps support this tag, suggestion: use same as subject</remarks>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Mensagem de observação
        /// </summary>
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Mensagem a ser exibida
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Resumo do texto para pre-visualização
        /// </summary>
        public string Preview { get; set; } = string.Empty;

        /// <summary>
        /// Ação a ser realizada com o botão
        /// </summary>
        public string ActionText { get; set; } = string.Empty;

        /// <summary>
        /// Link da Ação a ser realizada
        /// </summary>
        public string ActionLink { get; set; } = string.Empty;

        public string UnsubscribeLink { get; set; } = string.Empty;

        /// <summary>
        /// Caso verdadeiro, as variaveis não serão substituidas e retornara o template padrão
        /// </summary>
        public bool Test { get; set; }
    }
}
