# Operational activity contracts

Adds independent collaborator work state, full revision commands, immutable receipt DTOs and an authoritative store interface. All properties document their business meaning in English. Identifiers, reasons and text are bounded; deadlines require UTC; originating entity references and event keys are immutable after creation. Task state does not execute billing or telephony effects.

Validation: Base builds for netstandard2.0, net7.0 and net10.0 succeeded with zero errors (33 existing warnings). Relational store tests cover exact replay after newer revisions, changed replay rejection, actor isolation, stale revision rejection, terminal retention, origin deduplication, cross-context isolation, bounded cursor reads, history mutation guards and immutable references. Publication and installed API evidence are recorded in the consuming API delivery record; a contract package alone is not a deployed feature.

Pending program work: operational UI, delegated activity permissions, event adapters, reminders and financial-responsibility integration.
