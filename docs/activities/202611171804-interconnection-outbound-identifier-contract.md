# Resolução do Identificador de saída por interconexão

Contrato compartilhado com três modos. Desativado permite a tentativa sem aplicar Identificador de rota. Genérico encaminha o valor já autorizado e resolvido para a rota. Fixo usa diretamente o valor fornecido pelo cliente. Valor obrigatório ausente ou modo desconhecido rejeita a resolução. O contrato não consulta inventário nem altera o valor recebido.

O contrato foi integrado à prévia Blazor. Persistência e aplicação no FastAGI são fases posteriores. Build Release do Sufficit.Base nos três targets, 11 testes de contrato no Blazor e prova de salvamento, reabertura e simulação de valor fixo alfanumérico no Chromium.
