# Diretório de responsáveis financeiros

O cadastro informado já tem vínculo financeiro vigente, confirmado por consulta somente leitura. A projeção comercial ignorava identidades sem serviços. Nenhum dado de produção foi alterado.

- Base: campo JSON aditivo `financialResponsible`, omitido quando falso.
- EFData: consulta distinta de responsáveis explícitos vigentes; exclui autorreferência e GUID vazio.
- Standard: união somente no diretório de pesquisa, preservando resumos próprios, lista ativa e limpeza.
- API: regressões de autorização por texto/UUID para pagadores sem serviços.
- Blazor: papel visível e “Sem serviços”, localização e orientação do assistente atualizadas.

Validação: regressão Standard falhou antes da correção; 22 testes Standard, 8 Blazor e 173 API passaram após correção. Build do componente real e navegador em 1440/768/390 px passaram, com seleção preservando o ID do pagador. A primeira tentativa Blazor sem restore encontrou assets antigos; a restauração corrigiu o ambiente. Avisos de dependências preexistentes permanecem.

Referência visual: DESIGN.md e ClientList existente, seguindo Refero/sufficit-frontend. Sem novo layout ou alteração de cores. Evidência temporária: /tmp/financial-directory-preview.

Entrega: commits e push na main por repositório; publicação e confirmação de produção são acompanhadas separadamente. Esta atividade não comprova deploy.
