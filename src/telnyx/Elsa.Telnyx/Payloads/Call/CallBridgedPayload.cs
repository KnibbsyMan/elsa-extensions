﻿using Elsa.Telnyx.Attributes;
using Elsa.Telnyx.Payloads.Abstractions;

namespace Elsa.Telnyx.Payloads.Call;

[WebhookActivity(WebhookEventTypes.CallBridged, WebhookActivityTypeNames.CallBridged, "Call Bridged", "Triggered when an a call is bridged.")]
public sealed record CallBridgedPayload : CallPayload
{
    public string From { get; init; } = null!;
    public string To { get; init; } = null!;
    public string State { get; init; } = null!;
}