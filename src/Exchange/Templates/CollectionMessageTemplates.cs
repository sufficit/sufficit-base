#nullable enable
using System;
using System.Collections.Generic;

namespace Sufficit.Exchange.Templates
{
    /// <summary>
    ///     Reference collection templates (Hermes/WhatsApp), derived from the messages the billing team sends by hand.
    ///     They seed <c>exch_message_templates</c>; once stored, the database copy is the one operators edit.
    ///     Hermes renders <c>**text**</c> as bold.
    /// </summary>
    public static class CollectionMessageTemplates
    {
        public const string MessageType = "whatsapp";
        public const string MonthlyTitle = "sales.collection.monthly";
        public const string OverdueTitle = "sales.collection.overdue";

        /// <summary>Monthly boleto: services one per line, call balance only when informed (metered trunk).</summary>
        public static MessageTemplate Monthly(Guid contextId) => Build(MonthlyTitle, "Cobrança mensal — envio do boleto", contextId,
@"Olá!
Segue boleto ref. {{reference}} da empresa
**{{customer}}**

Serviços prestados:
{{#services}}
- {{service}} – {{amount}}
{{/services}}

Saldo para chamadas: {{call_balance}}

**Valor total do boleto: {{total}}**
**Vencimento: {{due_date}}**

Por favor, confirme o recebimento 😉
Qualquer dúvida, estou à disposição 🤝",
            Variable("reference", true, "Ex.: mensalidade de Novembro / mensalidades de Outubro e Novembro"),
            Variable("customer", true, "Razão social do cliente"),
            Variable("services", true, "Lista: service (nome e número) e amount (R$)"),
            Variable("call_balance", false, "Saldo para chamadas (somente com tronco tarifado)", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}$"),
            Variable("total", true, "Valor total do boleto", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}( \(.+\))?$"),
            Variable("due_date", true, "Vencimento do boleto (dd/MM/aaaa)", @"^\d{2}/\d{2}/\d{4}$"));

        /// <summary>Overdue reminder: no itemization, original due date, updated boleto attached.</summary>
        public static MessageTemplate Overdue(Guid contextId) => Build(OverdueTitle, "Cobrança de serviço vencido — boleto atualizado", contextId,
@"Olá!
Ainda não identificamos o pagamento do serviço que venceu dia {{overdue_date}} da empresa

**{{customer}}**

Segue boleto atualizado para facilitar.
**Valor: {{total}}**
**Novo vencimento: {{due_date}}**

Evite o bloqueio do serviço realizando o pagamento!
Qualquer dúvida, estou à disposição 🤝",
            Variable("overdue_date", true, "Vencimento original (dd/MM)", @"^\d{2}/\d{2}(/\d{4})?$"),
            Variable("customer", true, "Razão social do cliente"),
            Variable("total", false, "Valor do boleto atualizado", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}$"),
            Variable("due_date", false, "Vencimento do boleto atualizado (dd/MM/aaaa)", @"^\d{2}/\d{2}/\d{4}$"));

        public static IEnumerable<MessageTemplate> All(Guid contextId) => new[] { Monthly(contextId), Overdue(contextId) };

        private static MessageTemplate Build(string title, string description, Guid contextId, string body, params TemplateVariable[] variables)
        {
            var template = new MessageTemplate(title, description) { ContextId = contextId, IsApproved = true };
            template.Contents[MessageType] = new MessageTemplateContent { Body = body };
            foreach (var variable in variables) template.Variables[variable.Name] = variable;
            return template;
        }

        private static TemplateVariable Variable(string name, bool required, string description, string? pattern = null)
            => new TemplateVariable { Name = name, IsRequired = required, Description = description, ValidationPattern = pattern, Type = TemplateVariableType.String };
    }
}
