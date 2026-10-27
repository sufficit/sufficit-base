# Direção da portabilidade

Contrato aditivo em27/10/2026: `PortabilityDirection.Unknown`, `PortIn` e `PortOut`, relativos à Sufficit. JSON `direction` usa string; payloads anteriores sem o campo continuam Unknown. Nunca inferir entrada de todo o histórico.

`PortabilityProcess.NeedsReview` (`needsreview`) marca cadastros recebidos com dados incompletos. `IntakeKey` (`intakekey`, opcional) é correlação confiável calculada pelo backend, nunca um identificador produzido pelo modelo. Direção e revisão são filtros independentes em PortabilitySearchParameters; não equivalem ao status formal da solicitação.

A API restrita do Endpoints e o opt-in do Fleet estão em evolução coordenada. Publicar o contrato e aplicar a migração EFData antes dos novos leitores. Não transformar aviso de PortOut em consentimento automático ou status Completed. O recebimento não preenche documento, titular ou operadora contrária por suposição.
