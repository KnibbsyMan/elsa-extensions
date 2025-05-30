using Elsa.Telnyx.Models;
using Elsa.Workflows;

namespace Elsa.Telnyx.Extensions;

/// <summary>
/// Provides extensions on <see cref="ActivityExecutionContext"/>.
/// </summary>
public static class ActivityExecutionExtensions
{
    /// <summary>
    /// Creates a correlating client state.
    /// </summary>
    public static string CreateCorrelatingClientState(this ActivityExecutionContext context, string? activityInstanceId = null)
    {
        return new ClientStatePayload(context.WorkflowExecutionContext.Id, activityInstanceId).ToBase64();
    }
}