# Publicação dos presets de negócio Sufficit

Autorização: usuário pediu merge de todo o pendente nas mains e deploy para testar em 07/10/2026. Foram conciliadas as branches e alterações presentes no inventário inicial dos sete repositórios (Base, Identity.Core, EFData, Standard, Client, EndPoints e Blazor). Backups e stashes preservados; o app público sufficit-identity continua genérico, sem mudanças.

Presets pertencem a Standard (regras), EFData (intranet) e EndPoints (CRUD). Base/Client compartilham contrato/transporte; Blazor lê catálogo dinâmico e revalida versão antes de conceder claims pelo endpoint genérico existente. Seeds calls/telephony incluem BalanceViewEntitlement.NormalizedKey. Editar perfil não altera claims existentes; reaplicar perfil e renovar login para clientes afetados.

## Validação

- API completa: 763 testes aprovados; pré-pago/roteamento: 29; transação de deploy: 13.
- EFData: 719; Identity.Core: 41; Standard: 417 na suíte moderna e 117 na suíte principal selecionada.
- Blazor: build Server aprovado e 53 testes focados aprovados. Suíte completa: 873 aprovados, 23 ignorados, três falhas estáticas preexistentes (assets SUI transitivos, botão monitor, wrapper em representantes), fora dos arquivos alterados.
- Pacotes Base/Identity.Core 1.26.1007.1427, Client 1.26.1007.1445 e EFData 1.26.1007.1456 publicados e indexados. Mínimos atualizados nos consumidores. Primeiro CI consumidor falhou enquanto indexação pendente; Standard também precisou elevar mínimo EFData para o pacote com persistência Access.

## Banco e API

Backup completo do intranet no eveo-data: /root/sufficit-migration-audit/20261007-before-entitlement-presets-root.sql.gz (111031238 bytes, modo 0600, gzip válido, 106 tabelas e 611 INSERTs). Aplicado migrations/sql/Access/20261007_entitlement_presets.sql, SHA256 6717da60d3edb02c271a8746aae12f489d5556aa2fd865fd88b4b3121ffffa34. Conferidos calls com 3 itens e telephony com 9, ambos com balanceview; Galera Primary. Nenhuma concessão de claim efetuada. Verificação independente no nó Google não disponível por autenticação MariaDB root recusada; não foram tentadas credenciais alternativas.

API instalada pelo deploy.py oficial nos três nós (Eveo, Apoint, Castrum), versão 1.26.1007.1443+9a06ccb69ffbc3d7d9adb97a454149afc5e9dc68. Saúde Healthy e acesso anônimo a Access/EntitlementPresets recebe 401. SHA256 Sufficit.EndPoints.dll idêntico: 45a26c7d6d96eae8f8f6744de1481cda290e63bf92501b4e87c691665464f650. Backups /opt/sufficit-endpoints.before-811ba95a65b741578b8c7a25108b32eb (Eveo), .before-ec9625845e374ec39d226c01aa6fd0e1 (Apoint), .before-a2f8088825a54990b283b94db849e6f0 (Castrum). Configuração privada preservada. API autenticada validada por testes HTTP; navegação autenticada em produção fica para o usuário.

## Blazor e continuidade

Main dos presets 01e585a3199dced5c1a52badd1a2ccaec4c6f6c5 é ancestral de 11d275e8dadb729971ee3b77496f97c2f7895d8d, que agrega alterações de outras tarefas publicadas enquanto o CI rodava. Jobs antigos foram substituídos pelo push concorrente, sem retry de cancelamento. Deploy oficial iniciado do checkout original limpo, artefato server/publish-20261007120537 reutilizado nos três nós. Backup anterior em cada nó: /root/sufficit-deploy-audit/20261007-before-business-presets-blazor.tar.gz. Estado final da saúde e dos CIs será acrescentado após confirmação.

Deploy.py Blazor concluído e confirmado nos três nós às 15:09 UTC: Healthy 1.26.1007.1505+11d275e8dadb729971ee3b77496f97c2f7895d8d; hash do servidor idêntico ao artefato local (11eb156a82d96cd70c1db549cf37b260dcecdae20d2ccaf7436e74498fa9d0af). Saúde pública Healthy. CIs novos seguem em execução; conferência de versão após CI permanece necessária.

Registro remoto pendente: pushes de documentação recusados pelo GitHub com Internal Server Error (SSH e HTTPS), após conferir remote main. Código funcional já publicado; docs preservados localmente. CIs finais: Standard 37642087741, API 37642093573, Blazor Server 37641817155 e Shared 37641816884 em execução às 15:15 UTC. Jobs anteriores Blazor substituídos por push concorrente; nenhum cancelamento manual solicitado pelo usuário.
