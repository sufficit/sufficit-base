# Consulta de rascunhos de compromisso

## Implementação
- Base: DTO CallCreditCommitmentDraft em Sufficit.Finance, distinto da política ativa.
- EFData: mapeamento da tabela existente fina_call_credit_commitment_drafts com GUID little-endian, valores e evidência preservados. Nenhuma nova migração ou escrita de banco nesta etapa.
- Standard: leitura por ContextId não vazio, sem tracking e sem criar/ativar política.
- EndPoints: GET Telephony/Billing/Commitment/Draft?contextId=..., exclusivo SalesManager/Administrator. Sem rascunho retorna 204; contexto vazio 400.
- Client: método GetCommitmentDraft com cancelamento e resposta nula para 204.
- Blazor, worktree feat/call-credit-commitment: painel de leitura na página de tarifas do cliente, apenas gestor; mediana sugerida, intervalo observado, ciclo sugerido, ressalva sobre mínimo/aniversário e tabela expansível das recargas. Falha não é ausência nem descumprimento. Troca de contexto limpa estado anterior e descarta carregamento cancelado.
- Sidecar AI expõe somente rascunho carregado e sua natureza de sugestão, sem ação de aprovação/reset.

## Validação
20 testes Standard de compromisso aprovados, incluindo leitura isolada/detached, preservação de revisão e nenhuma política criada. Quatro testes EndPoints aprovados: metadados de autorização e rejeição de Guid.Empty antes do banco, não equivalem a login HTTP real. Build da API concluído pelo test runner. Build Blazor e fixture net10.0 concluídos, após corrigir colisão entre JsonException local e System.Text.Json.JsonException.

Navegador com componente real: sugestão, expansão de três recargas, viewport 390px sem overflow, ausência, erro de consulta e JSON inválido. Screenshot revisada: /mnt/workspaces/sufficit/tmp/commitment-draft-mobile.png. Fixture em validation/commitment-preview (ignorada no git), não substitui validação autenticada do fluxo completo/API/banco. Logs commitment-draft-tests.log, commitment-draft-api-tests.log e commitment-draft-preview.log em tmp do workspace.

## Limites de entrega
Código local, não publicado. Os 55 rascunhos previamente persistidos permanecem no banco; esta etapa não os alterou. A tela de produção ainda não recebe esta implementação. Aprovação/edição de mínimo, recorrência e aniversário, integração de eventos reais e redefinição auditada continuam no plano principal. A feature completa não está pronta para deploy. Nenhum saldo, tarifa ou serviço foi alterado e MSSQL permanece necessário.
