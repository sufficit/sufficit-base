using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Catalog of known step actions. A new action is added here first, then implemented by its consumer;
    ///     schedules cannot reference a key that no consumer understands.
    /// </summary>
    public static class ServiceRuleActions
    {
        public const string CustomerReminder = "customer-reminder";
        public const string InternalAlert = "internal-alert";
        public const string ManagerReminder = "manager-reminder";
        public const string AccessBlock = "access-block";
        public const string OutboundBlock = "outbound-block";
        public const string InboundBlock = "inbound-block";
        public const string Suspend = "suspend";
        public const string ExportData = "export-data";
        public const string CloseContract = "close-contract";
        public const string ArchiveAccount = "archive-account";
        public const string DeleteAccount = "delete-account";

        public static IReadOnlyList<ServiceRuleActionDefinition> All { get; } = new[]
        {
            new ServiceRuleActionDefinition { Key = CustomerReminder, Title = "Lembrete ao cliente", Description = "Mensagem com o link de pagamento.", Category = ServiceRuleActionCategory.Notification, DefaultAudience = ServiceRuleAudience.Customer, UsesChannels = true, Consumers = "endpoints" },
            new ServiceRuleActionDefinition { Key = InternalAlert, Title = "Alerta no sistema", Description = "Aviso destacado dentro do produto para quem administra a conta.", Category = ServiceRuleActionCategory.Notification, DefaultAudience = ServiceRuleAudience.AccountAdministrators, Consumers = "hermes" },
            new ServiceRuleActionDefinition { Key = ManagerReminder, Title = "Lembrete à equipe", Description = "Avisa a equipe Sufficit para acompanhar o caso.", Category = ServiceRuleActionCategory.Notification, DefaultAudience = ServiceRuleAudience.Internal, UsesChannels = true, Consumers = "endpoints" },
            new ServiceRuleActionDefinition { Key = AccessBlock, Title = "Bloquear acesso", Description = "Painel e API bloqueados; canais continuam recebendo.", Category = ServiceRuleActionCategory.Restriction, DefaultAudience = ServiceRuleAudience.AccountUsers, Consumers = "hermes" },
            new ServiceRuleActionDefinition { Key = OutboundBlock, Title = "Bloquear chamadas de saída", Category = ServiceRuleActionCategory.Restriction, DefaultAudience = ServiceRuleAudience.Customer, Consumers = "telephony" },
            new ServiceRuleActionDefinition { Key = InboundBlock, Title = "Bloquear chamadas de entrada", Category = ServiceRuleActionCategory.Restriction, DefaultAudience = ServiceRuleAudience.Customer, Consumers = "telephony" },
            new ServiceRuleActionDefinition { Key = Suspend, Title = "Suspender", Description = "Serviço suspenso; entradas descartadas até o pagamento.", Category = ServiceRuleActionCategory.Restriction, DefaultAudience = ServiceRuleAudience.AccountUsers, Consumers = "hermes,telephony" },
            new ServiceRuleActionDefinition { Key = ExportData, Title = "Exportar dados", Description = "Gera a exportação entregue ao cliente antes de qualquer exclusão.", Category = ServiceRuleActionCategory.Operation, DefaultAudience = ServiceRuleAudience.Internal, Consumers = "hermes" },
            new ServiceRuleActionDefinition { Key = CloseContract, Title = "Encerrar contrato", Category = ServiceRuleActionCategory.Termination, DefaultAudience = ServiceRuleAudience.Internal, Consumers = "endpoints" },
            new ServiceRuleActionDefinition { Key = ArchiveAccount, Title = "Arquivar conta", Category = ServiceRuleActionCategory.Operation, DefaultAudience = ServiceRuleAudience.Internal, Consumers = "hermes", Requires = ExportData },
            new ServiceRuleActionDefinition { Key = DeleteAccount, Title = "Excluir conta", Description = "Irreversível.", Category = ServiceRuleActionCategory.Termination, DefaultAudience = ServiceRuleAudience.Internal, Consumers = "hermes", Requires = ExportData },
        };

        public static ServiceRuleActionDefinition? Find(string? key)
            => string.IsNullOrWhiteSpace(key) ? null : All.FirstOrDefault(a => string.Equals(a.Key, key!.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}
