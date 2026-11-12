#if NET10_0_OR_GREATER
using System;
namespace Sufficit.Telephony;

/// <summary>Insert-only request with an optional compatible ten-character password.</summary>
public sealed record EndPointCreationRequest(Guid RequestId, Guid ContextId, string Number, string Description, string Technology = "SIP+PJSIP", bool Recording = true, string ExpectedTitle = "", string? Password = null);
public sealed record EndPointCreationPreview(Guid ContextId, string Number, string Title, string Technology = "SIP+PJSIP", bool Recording = true);
public sealed record EndPointCreationResult(Guid Id, Guid ContextId, string Number, string Title, bool AlreadyCreated, bool? RuntimeApplicationConfirmed = null);

public sealed record EndPointCreationAudit(Guid Id, Guid ContextId, string Number, string Description, string Technology, bool Recording);

#endif
