# Simulação das réguas com dados reais — 28/10/2026

Somente leitura (banco `intranet`, eveo-apps). Nenhum caso aberto, nenhum evento emitido. "Até hoje" = marcos que já
teriam sido emitidos se o caso estivesse aberto desde o D0 e nada tivesse sido pago.

## Hospedagem Hermes (ativa) — assunto `sales.contract-period`, D0 = `sals_contracts.next_due_date`
13 contratos ativos (sem os pilotos de teste), 10 vencimentos distintos entre 03/11 e 27/11. **Nenhum marco até hoje.**
Primeiro da fila: contexto `6EA53E02…` vence 03/11 → lembrete 31/10 · alerta 03/11 · bloqueio 04/11 · suspensão 08/11 ·
encerrar + exportar/excluir 03/12. Contratos `Canceled`/`Expired` (TOGO 21/10, legados 19–21/10) não abrem caso.
NETPLAYGO e S.T.I. (casos do plano) não aparecem com vencimento ativo no catálogo Hermes.

## DIDs (rascunho) — assunto `telephony.did`, D0 = vencimento do TRONCO DE ENTRADA
814 contratos ativos; **551 com `next_due_date` vencido (01/10–28/10)** — provável data legada não avançada / débito em
saldo, não inadimplência confirmada. Se todos estivessem em aberto:
- 92 entre D0 e D+2 → só o aviso de cobrança.
- 459 em D+3 ou mais → 18 são 0800 (bloqueio de entrada no D+3) e 441 fixo/móvel aguardando leitura do aviso.
- Nenhum em D+90; a primeira revisão final cairia em 30/12.
Conclusão: antes de ativar, a Telefonia precisa abrir caso só para período realmente não pago.

## Recarga obrigatória (rascunho) — assunto `telephony.recharge-cycle`, D0 = fim do ciclo
1 compromisso ativo: contexto `6EA53E02…`, R$ 150/mês, aniversário 08/10. Ciclo atual 08/10–08/11 →
lembrete 03/11 (só se faltar recarga) · avaliação 08/11 · restauração de tarifas 11/11 (se não cumprido).
Nada até hoje.

## Refeita em 29/10/2026 com a regra de devedor (`sufficit-endpoints/docs/CUSTOMER-DEBT.md`)
Devedor = saldo atual negativo em `fina_financial_records`; D0 = "devedor desde" (créditos aplicados aos débitos em
ordem cronológica; o débito mais antigo não coberto). 183 clientes negativos (R$ −42.586,20), 19 com serviço ativo.
- **Hermes:** nenhum cliente com Hermes ativo está devedor → nenhum marco.
- **DIDs:** 16 clientes devedores com tronco de entrada ativo (2 com 0800). Todos já passaram de D+3; 2 passaram de
  D+90 (`04FB1CD2…` desde 03/07, R$ −500; `414B6193…` desde 28/07, R$ −344). Dívidas mínimas aparecem
  (R$ −0,01, −3, −10): falta um valor mínimo para abrir caso — configuração do módulo dono, não da régua.
- **Recarga:** inalterado (não depende de saldo).
- 3 clientes devedores têm só outros serviços (sem régua).

## Simulação consolidada — 29/10/2026 (regras atuais, pior caso: ninguém paga)
D0 = fim da cobertura paga (legado: snapshot `End` −3 h, `Renewed=false`; nativo: período corrente, avança se o saldo
não está negativo). Régua por serviço: Hermes → corte Hermes; TRONCO DE ENTRADA → DIDs mensal, ou adiantado se a
cobertura paga ≥ 2 meses; recarga → ciclo do compromisso. Fora das réguas: 232 troncos tarifados, 403 outros serviços.

Casos: 741 DIDs mensais, 13 DIDs adiantados, 13 Hermes, 1 recarga.

**Estado hoje:** 67 avisos de cobrança de DID já teriam saído e **9 DIDs já estariam bloqueados** (5 clientes com
cobertura vencida há 30–87 dias: D5EAE2E9 ×5 em D+42, 295D054E D+60, 81A2EB18 D+87 — revisão final em 01/11 —,
5205863D D+30, 8357B3BA ×2 D+45). Nenhum Hermes vencido.

**Próximos 30 dias (29/10–28/11):** 646 lembretes de pagamento (D-3) · 622 avisos de cobrança (D0) · 59 bloqueios de
entrada de DID · Hermes: 13 alertas, 13 bloqueios de acesso, 12 suspensões · 2 revisões finais · recarga: lembrete 03/11,
avaliação 08/11, restauração de tarifas 11/11 (se não cumprido). Pico: 25/11 com 13 bloqueios de entrada.

Leitura: o pior caso trata como devedor todo DID que renova no período. Na prática a régua só abre caso quando a
cobertura vence sem pagamento — hoje ~55–64 de ~754 DIDs estão nessa situação (≈ 8 %), então os avisos de cobrança
reais devem ficar perto de 1/12 do pior caso e os lembretes D-3 (que vão para todos) é que dominam o volume.
