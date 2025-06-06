namespace Elsa.Telnyx.Bookmarks;

/// <summary>
/// A bookmark payload for Telnyx webhook events.
/// </summary>
/// <param name="EventType">The event type.</param>
/// <param name="CallControlId">An optional call control ID.</param>
public record WebhookEventStimulus(string EventType, string? CallControlId = null);