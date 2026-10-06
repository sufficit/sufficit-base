# Explicit operational activity source events

Added OperationalActivityRequestedEvent with stable event/command/activity identity, context, correlation, UTC source occurrence and requested work details. Mapping validates the complete creation command, records source occurrence in its immutable reason and cannot request a state update or reopen terminal work. Authentication still supplies the actor. No arbitrary sales event is interpreted as an activity request.

All three Base targets build with zero errors (existing warnings). Relational/API replay and access tests and publication are tracked in PLAN-ACTIVITY-SOURCE-EVENTS.md. No database or production activity was changed.
