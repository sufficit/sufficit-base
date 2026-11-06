# Relatórios sem restrição de dias

Removidos os limites de 31 dias e de 48 horas dos relatórios de telefonia, na interface, validação da API e construtor do relatório por hora. MaximumHours=0 sinaliza ausência de limite de duração. Mantidas datas válidas/ordenadas, autorização, cancelamento, timeout de três minutos e limite de 100.000 linhas com erro explícito, sem resultado parcial.

Validação: 14 testes específicos; 210 testes contra o candidato publicado incluindo relatórios, CustomerSearch, InternalPermission, BillingCheckout e Voice; closure sem referências ausentes e 2.783 tipos carregados. Navegador com dados sintéticos em 1440/768/390: seis meses, horários, Excel, paginação, retorno pela URL, cancelamento e troca de cliente. Não executados relatórios extensos na produção.

Código: Base c1029a8; Standard 4e598b8; EndPoints c5f407d; Blazor 498fa0bd. Candidato Blazor inclui commit subsequente 5a368b63 (teste de checklist, sem reversão desta mudança).

Publicação oficial deploy.py em eveo-apps, apoint-apps e castrum-apps: API 1.26.1106.1658+c5f407d; Blazor 1.26.1106.1659+5a368b63. Conferidos 559 arquivos DLL/WASM da API e 213 do Blazor por host, todos Healthy. Catálogo autenticado em cada API retorna nove modelos com MaximumHours=0. Catálogo comercial responde com 23 itens e quatro vínculos ProductId. Saúde pública Blazor confirmada.
