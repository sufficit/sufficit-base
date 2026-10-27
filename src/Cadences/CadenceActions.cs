using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Catalog of known step actions, shared by every module. A new action is added here first, then implemented by
    ///     its consumer; cadences cannot reference a key no consumer understands.
    /// </summary>
    public static class CadenceActions
    {
        // Any module
        public const string Notify = "notify";
        public const string InternalAlert = "internal-alert";
        public const string ManagerReminder = "manager-reminder";
        public const string Review = "review";

        // Sales / Hermes
        public const string CustomerReminder = "customer-reminder";
        public const string AccessBlock = "access-block";
        public const string Suspend = "suspend";
        public const string ExportData = "export-data";
        public const string CloseContract = "close-contract";
        public const string ArchiveAccount = "archive-account";
        public const string DeleteAccount = "delete-account";

        // Telephony
        public const string OutboundBlock = "outbound-block";
        public const string InboundBlock = "inbound-block";
        public const string ReleaseNumber = "release-number";

        public static IReadOnlyList<CadenceActionDefinition> All { get; } = new[]
        {
            new CadenceActionDefinition { Key = Notify, Title = "Enviar notificação", Description = "Mensagem pelo módulo de notificações aos inscritos ou destinatários.", Category = CadenceActionCategory.Notification, DefaultAudience = CadenceAudience.Customer, UsesChannels = true, Consumers = "notification", ParametersLabel = "Template (título)" },
            new CadenceActionDefinition { Key = InternalAlert, Title = "Alerta no sistema", Description = "Aviso destacado dentro do produto para quem administra a conta.", Category = CadenceActionCategory.Notification, DefaultAudience = CadenceAudience.AccountAdministrators, Consumers = "hermes,blazor" },
            new CadenceActionDefinition { Key = ManagerReminder, Title = "Lembrete à equipe", Description = "Avisa a equipe Sufficit para acompanhar o caso.", Category = CadenceActionCategory.Notification, DefaultAudience = CadenceAudience.Internal, UsesChannels = true, Consumers = "notification" },
            new CadenceActionDefinition { Key = Review, Title = "Abrir revisão", Description = "Cria atividade para decisão humana.", Category = CadenceActionCategory.Operation, DefaultAudience = CadenceAudience.Internal, Consumers = "tasks" },

            new CadenceActionDefinition { Key = CustomerReminder, Title = "Lembrete de pagamento", Description = "Mensagem com o link de pagamento.", Category = CadenceActionCategory.Notification, DefaultAudience = CadenceAudience.Customer, UsesChannels = true, Module = CadenceModules.Sales, Consumers = "endpoints" },
            new CadenceActionDefinition { Key = AccessBlock, Title = "Bloquear acesso", Description = "Painel e API bloqueados; canais continuam recebendo.", Category = CadenceActionCategory.Restriction, DefaultAudience = CadenceAudience.AccountUsers, Module = CadenceModules.Sales, Consumers = "hermes" },
            new CadenceActionDefinition { Key = Suspend, Title = "Suspender", Description = "Serviço suspenso; entradas descartadas até resolver.", Category = CadenceActionCategory.Restriction, DefaultAudience = CadenceAudience.AccountUsers, Module = CadenceModules.Sales, Consumers = "hermes,telephony" },
            new CadenceActionDefinition { Key = ExportData, Title = "Exportar dados", Description = "Exportação entregue ao cliente antes de qualquer exclusão.", Category = CadenceActionCategory.Operation, DefaultAudience = CadenceAudience.Internal, Module = CadenceModules.Sales, Consumers = "hermes" },
            new CadenceActionDefinition { Key = CloseContract, Title = "Encerrar contrato", Category = CadenceActionCategory.Termination, DefaultAudience = CadenceAudience.Internal, Module = CadenceModules.Sales, Consumers = "endpoints" },
            new CadenceActionDefinition { Key = ArchiveAccount, Title = "Arquivar conta", Category = CadenceActionCategory.Operation, DefaultAudience = CadenceAudience.Internal, Module = CadenceModules.Sales, Consumers = "hermes", Requires = ExportData },
            new CadenceActionDefinition { Key = DeleteAccount, Title = "Excluir conta", Description = "Irreversível.", Category = CadenceActionCategory.Termination, DefaultAudience = CadenceAudience.Internal, Module = CadenceModules.Sales, Consumers = "hermes", Requires = ExportData },

            new CadenceActionDefinition { Key = OutboundBlock, Title = "Bloquear chamadas de saída", Category = CadenceActionCategory.Restriction, DefaultAudience = CadenceAudience.Customer, Module = CadenceModules.Telephony, Consumers = "telephony" },
            new CadenceActionDefinition { Key = InboundBlock, Title = "Bloquear chamadas de entrada", Category = CadenceActionCategory.Restriction, DefaultAudience = CadenceAudience.Customer, Module = CadenceModules.Telephony, Consumers = "telephony" },
            new CadenceActionDefinition { Key = ReleaseNumber, Title = "Liberar número", Description = "Desvincula o número (quarentena ou cancelamento no fornecedor).", Category = CadenceActionCategory.Termination, DefaultAudience = CadenceAudience.Internal, Module = CadenceModules.Telephony, Consumers = "telephony" },
        };

        public static CadenceActionDefinition? Find(string? key)
            => string.IsNullOrWhiteSpace(key) ? null : All.FirstOrDefault(a => string.Equals(a.Key, key!.Trim(), StringComparison.OrdinalIgnoreCase));

        /// <summary>Actions offered to a module: its own plus the generic ones.</summary>
        public static IEnumerable<CadenceActionDefinition> For(string? module)
            => All.Where(a => a.Module.Length == 0 || string.Equals(a.Module, module, StringComparison.OrdinalIgnoreCase));
    }
}
