# Cobrança consolidada por cliente e período

## Entrega local
- Planos por cliente e destinatário verificados, janela configurável 0–30 dias, padrão 7. Antecedência separada, padrão 7 dias antes da primeira data.
- Paginação por cem clientes, com serviços completos no mesmo snapshot. Pagamento e revisão ficam separados da agenda; truncamento invalida ações.
- Diário existente compartilhado por cliente/destinatário/mês da primeira data: uma abordagem inicial, lembrete/complemento justificados, autoria, revisão e replay exato.
- Conjuntos não incluídos no contato anterior continuam visíveis como complemento a avaliar. Mudança de filtro sem mudança dos serviços não apaga a identificação do registro.
- Cards com total nominal e detalhes dos serviços, aba Já abordados, retorno e conferência declarada do histórico do Hermes. Assistente somente leitura atualizado.
- Nenhuma mensagem enviada, boleto consolidado criado, planilha modificada ou alteração de multa/bloqueio efetuada. Nenhuma alteração de chaves SSH ou configurações de produção.

## Evidência
- Política: 35 testes aprovados.
- Paginação SQLite: 11 testes aprovados; inclui 205 serviços do mesmo cliente e fronteira de cem clientes.
- Diário SQLite real: segundo operador não consegue registrar outra abordagem inicial; replay da primeira solicitação preservado após lembrete de outro operador (1 teste aprovado).
- Build Release integrado da API e do preview da página real: zero erros, avisos existentes de dependências/projeto presentes.
- Navegador: agrupamento/total, teclado, conferência obrigatória, contato inicial, resposta perdida/replay, retorno compartilhado, complemento de outro grupo, filtros e datas futuras, em 1600/800/390.
- Cards: geometria/contraste e navegação em claro/escuro, desktop/tablet/celular. Capturas sintéticas; não é validação autenticada em produção.
- Comandos com referências coerentes dos worktrees via CustomAfterMicrosoftCommonTargets=/mnt/workspaces/sufficit/tmp/collection-coverage-build.targets, VersionSuffix=1.99.0.0. O arquivo de override é exclusivo da validação local e não faz parte do runtime/publicação.

## Limites
Hermes não é cruzado automaticamente: não existe associação inequívoca implantada entre mensagens históricas e esta agenda. O gestor precisa conferir e declarar a conferência. Não representar esse histórico como ausência de cobrança nem como entrega confirmada.
Agenda mensal não é competência fiscal. Recargas tarifadas não são incluídas como mensalidades. Limites de consulta: 2.000 contratos por página e 10.000 entradas por fonte; diário resumido usa últimos cinquenta registros e editor oferece histórico paginado; um registro admite até sessenta serviços e notas de quinhentos caracteres.

## Publicação pendente
Nenhum push, merge ou deploy realizado para esta funcionalidade. Preparar integração ordenada Base → EFData → Standard/Client → EndPoints → Blazor, verificar versões consumidas e executar fluxo oficial com backup/saúde. O AGENTS.md do Blazor exige aprovação explícita por ação operacional, incluindo integrações de branches/PRs. A decisão de publicar precisa abranger estes seis repositórios, sem incluir alterações alheias nos checkouts originais.

Plano e evidência detalhada pertencem a esta sessão: 01a0e328-33b8-78c0-9864-2ed58f77d221. Registro central em sufficit-blazor-collections-layout/docs/PLAN-COLLECTION-PERIODS.md e COLLECTION-PERIODS-HERMES.md.

Repositório: base.
