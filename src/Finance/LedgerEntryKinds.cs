using System;
using System.Collections.Generic;

namespace Sufficit.Finance
{
    /// <summary>
    ///     Identities of ledger entry kinds (<c>intranet.fina_entry_kinds.id</c>, stored as <c>binary(16)</c> in
    ///     <c>fina_financial_records.kind_id</c>). Compare entries by these ids, never by the free-text kind.
    ///     Titles and texts live in the catalog table, so a rename never requires migrating ledger rows.
    /// </summary>
    /// <remarks>
    ///     A database trigger fills <c>kind_id</c> from the written text (current or former kinds) for every writer.
    ///     Migration: sufficit-efdata migrations/sql/Finance/202611131700-ledger-entry-kinds.sql.
    /// </remarks>
    public static class LedgerEntryKinds
    {
        /// <summary>Pagamento por boleto (pagb - pagamento boleto).</summary>
        public static readonly Guid PaymentBankSlip = new Guid("01a5fc0a-8886-462b-ae5c-2d15cb44bcb1");
        /// <summary>Pagamento por cartão (pagc - pagamento cartao).</summary>
        public static readonly Guid PaymentCard = new Guid("0bbc4427-2f87-45a7-a764-a484ee686300");
        /// <summary>Pagamento por PIX/TED (pagt - pagamento ted).</summary>
        public static readonly Guid PaymentTransfer = new Guid("de5bee72-d0c9-437f-bc4a-d8015f2b72b1");
        /// <summary>Pagamento por Mercado Pago (pagm - pagamento mercado pago).</summary>
        public static readonly Guid PaymentMercadoPago = new Guid("3206b2cd-a13d-426a-8634-bab563761a25");
        /// <summary>Pagamento por depósito (pagp - pagamento deposito).</summary>
        public static readonly Guid PaymentDeposit = new Guid("df3f528d-8e89-408a-88e6-f74505502a44");
        /// <summary>Pagamento em dinheiro (pagd - pagamento dinheiro).</summary>
        public static readonly Guid PaymentCash = new Guid("6b6d014e-baac-4190-9647-49754cd2feff");
        /// <summary>Pagamento em cheque (pagq - pagamento cheque).</summary>
        public static readonly Guid PaymentCheck = new Guid("d6a55f39-5695-4922-b212-7456464e1524");
        /// <summary>Ativação de serviço (ativ - ativacao).</summary>
        public static readonly Guid ServiceActivation = new Guid("886595fa-696e-48a6-8803-40fa66d56385");
        /// <summary>Transferência (saída) (trns - transferencia).</summary>
        public static readonly Guid TransferOut = new Guid("f23d1688-9e0b-4911-9448-14ac9afcee57");
        /// <summary>Transferência (entrada) (trne - transferencia).</summary>
        public static readonly Guid TransferIn = new Guid("7b1c05d7-3b77-43b7-ac0d-f9303cae8ef0");
        /// <summary>Comissão recebida (cmrb - comissao).</summary>
        public static readonly Guid CommissionReceived = new Guid("d3e9a0d5-8f1a-43ca-a663-d5512b4e3037");
        /// <summary>Comissão paga (cmpg - comissao).</summary>
        public static readonly Guid CommissionPaid = new Guid("ecd63249-99a8-4c7a-b2e3-8e59e035875a");
        /// <summary>Bônus (bons - bonus).</summary>
        public static readonly Guid Bonus = new Guid("0117571c-6158-45b1-87ba-8c8e5f8eb500");
        /// <summary>Depósito bancário (legado) (depo - deposito bancario).</summary>
        public static readonly Guid BankDeposit = new Guid("3ab2efae-778c-4b22-89c8-1b2fd59b8959");
        /// <summary>Despesa VoIP (vpdp - voip despesa).</summary>
        public static readonly Guid VoipExpense = new Guid("29b82162-6ab0-4068-8dc9-84571c193d38");
        /// <summary>Envio de SMS (smse - sms envio).</summary>
        public static readonly Guid SmsSending = new Guid("9d74bde3-1a09-4ec9-94a4-86c249b6ddfd");
        /// <summary>Dinheiro avulso (dhav - dinheiro avulso).</summary>
        public static readonly Guid CashAdjustment = new Guid("9230fd01-5bac-412c-9fb3-0aa860aee816");
        /// <summary>Balancete (blct - balancete).</summary>
        public static readonly Guid BalanceSheetAdjustment = new Guid("7e78f007-44f1-429f-84f7-d7ab8adad46a");
        /// <summary>Auditoria (audt - auditoria).</summary>
        public static readonly Guid Audit = new Guid("2f3f882e-64bf-4b6d-a83d-c84432ca4657");
        /// <summary>Registro padrão (deft - registro padrao).</summary>
        public static readonly Guid Default = new Guid("96857ce8-0533-47c2-af82-ba4f09a0916a");
        /// <summary>Problema (erro - problema).</summary>
        public static readonly Guid Problem = new Guid("42928101-c937-4493-90e5-bd1744dcec40");
        /// <summary>Não classificado (desc - indiscriminado).</summary>
        public static readonly Guid Unclassified = new Guid("9a21d73e-2ada-435d-a6d4-089709d11f1d");

        /// <summary>Kinds that represent money received (payments). A payment is never a call-credit purchase.</summary>
        private static readonly HashSet<Guid> PaymentSet = new HashSet<Guid>
        {
            PaymentBankSlip, PaymentCard, PaymentTransfer, PaymentMercadoPago, PaymentDeposit, PaymentCash, PaymentCheck
        };

        /// <summary>Kinds that represent money received (payments).</summary>
        public static IReadOnlyCollection<Guid> Payments => PaymentSet;

        public static bool IsPayment(Guid kindId) => PaymentSet.Contains(kindId);
    }
}
