#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>Field names grouped by family (customer.*, service.*, billing.*, telephony.*); multi-word names use further dots (billing.due.date).</summary>
        public static class Fields
        {
            public const string CustomerTitle = "customer.title";
            /// <summary>List of the customer's services; each item has <see cref="ServiceTitle"/> and <see cref="ServiceAmount"/>.</summary>
            public const string Services = "services";
            public const string ServiceTitle = "service.title";
            public const string ServiceAmount = "service.amount";
            public const string BillingReference = "billing.reference";
            public const string BillingTotal = "billing.total";
            public const string BillingDueDate = "billing.due.date";
            public const string BillingOverdueDate = "billing.overdue.date";
            public const string CallBalance = "telephony.balance";

            /// <summary>Previous flat names (before 27/11/2026) and their family names, for migrating stored templates.</summary>
            public static readonly IReadOnlyDictionary<string, string> Legacy = new Dictionary<string, string>
            {
                ["customer"] = CustomerTitle, ["service"] = ServiceTitle, ["amount"] = ServiceAmount, ["reference"] = BillingReference,
                ["total"] = BillingTotal, ["due_date"] = BillingDueDate, ["overdue_date"] = BillingOverdueDate, ["call_balance"] = CallBalance,
                ["billing.due_date"] = BillingDueDate, ["billing.overdue_date"] = BillingOverdueDate, ["telephony.call_balance"] = CallBalance,
            };
        }

        /// <summary>Monthly boleto: services one per line, call balance only when informed (metered trunk).</summary>
        public static MessageTemplate Monthly(Guid contextId) => Build(MonthlyTitle, "Cobrança mensal — envio do boleto", contextId,
@"Olá!
Segue boleto ref. {{billing.reference}} da empresa
**{{customer.title}}**

Serviços prestados:
{{#services}}
- {{service.title}} – {{service.amount}}
{{/services}}

Saldo de créditos para chamadas: {{telephony.balance}}

**Valor total do boleto: {{billing.total}}**
**Vencimento: {{billing.due.date}}**

Por favor, confirme o recebimento 😉
Qualquer dúvida, estou à disposição 🤝",
            Variable(Fields.BillingReference, true, "Ex.: mensalidade de Novembro / mensalidades de Outubro e Novembro"),
            Variable(Fields.CustomerTitle, true, "Razão social do cliente"),
            Variable(Fields.Services, true, "Lista: service.title (nome e número) e service.amount (R$)"),
            Variable(Fields.CallBalance, false, "Saldo de créditos para chamadas (somente com tronco tarifado)", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}$"),
            Variable(Fields.BillingTotal, true, "Valor total do boleto", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}( \(.+\))?$"),
            Variable(Fields.BillingDueDate, true, "Vencimento do boleto (dd/MM/aaaa)", @"^\d{2}/\d{2}/\d{4}$"));

        /// <summary>Overdue reminder: no itemization, original due date, updated boleto attached.</summary>
        public static MessageTemplate Overdue(Guid contextId) => Build(OverdueTitle, "Cobrança de serviço vencido — boleto atualizado", contextId,
@"Olá!
Ainda não identificamos o pagamento do serviço que venceu dia {{billing.overdue.date}} da empresa

**{{customer.title}}**

Segue boleto atualizado para facilitar.
**Valor: {{billing.total}}**
**Novo vencimento: {{billing.due.date}}**

Evite o bloqueio do serviço realizando o pagamento!
Qualquer dúvida, estou à disposição 🤝",
            Variable(Fields.BillingOverdueDate, true, "Vencimento original (dd/MM)", @"^\d{2}/\d{2}(/\d{4})?$"),
            Variable(Fields.CustomerTitle, true, "Razão social do cliente"),
            Variable(Fields.BillingTotal, false, "Valor do boleto atualizado", @"^R\$ ?\d{1,3}(\.\d{3})*,\d{2}$"),
            Variable(Fields.BillingDueDate, false, "Vencimento do boleto atualizado (dd/MM/aaaa)", @"^\d{2}/\d{2}/\d{4}$"));

        /// <summary>
        ///     Renames the previous flat field names (<see cref="Fields.Legacy"/>) to the family names in every content and
        ///     in the declared variables, keeping all other text, descriptions and formats. Returns true when anything changed.
        /// </summary>
        public static bool RenameLegacyFields(MessageTemplate template)
        {
            var changed = false;
            foreach (var content in template.Contents.Values)
            {
                if (content == null) continue;
                var body = System.Text.RegularExpressions.Regex.Replace(content.Body ?? string.Empty, @"\{\{\s*([#/]?)([A-Za-z0-9_.]+)\s*\}\}",
                    m => Fields.Legacy.TryGetValue(m.Groups[2].Value, out var name) ? "{{" + m.Groups[1].Value + name + "}}" : m.Value);
                if (body != content.Body) { content.Body = body; changed = true; }
            }
            if (template.Variables.Keys.Any(k => Fields.Legacy.ContainsKey(k)))
            {
                // Rebuild in the original order so the fields keep their position on screen.
                var renamed = new Dictionary<string, TemplateVariable>();
                foreach (var pair in template.Variables)
                {
                    var name = Fields.Legacy.TryGetValue(pair.Key, out var family) && !template.Variables.ContainsKey(family) ? family : pair.Key;
                    if (pair.Value != null) pair.Value.Name = name;
                    renamed[name] = pair.Value!;
                }
                template.Variables = renamed;
                changed = true;
            }
            return changed;
        }

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
