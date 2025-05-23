using Elsa.Extensions;
using Elsa.ServiceBus.AzureServiceBus.Activities;
using Elsa.ServiceBus.AzureServiceBus.Contracts;
using Elsa.ServiceBus.AzureServiceBus.Models;
using Elsa.Mediator.Contracts;
using Elsa.Workflows.Runtime.Notifications;
using JetBrains.Annotations;

namespace Elsa.ServiceBus.AzureServiceBus.Handlers;

/// <summary>
/// Creates workers for each trigger &amp; bookmark in response to updated workflow trigger indexes and bookmarks.
/// </summary>
[UsedImplicitly]
public class UpdateWorkers(IWorkerManager workerManager) : INotificationHandler<WorkflowTriggersIndexed>, INotificationHandler<WorkflowBookmarksIndexed>
{
    /// <summary>
    /// Adds, updates and removes workers based on added and removed triggers.
    /// </summary>
    public async Task HandleAsync(WorkflowTriggersIndexed notification, CancellationToken cancellationToken)
    {
        var added = notification.IndexedWorkflowTriggers.AddedTriggers.Filter<MessageReceived>().Select(x => x.GetPayload<MessageReceivedStimulus>());
        await StartWorkersAsync(added, cancellationToken);
    }

    /// <summary>
    /// Adds, updates and removes workers based on added and removed bookmarks.
    /// </summary>
    public async Task HandleAsync(WorkflowBookmarksIndexed notification, CancellationToken cancellationToken)
    {
        var added = notification.IndexedWorkflowBookmarks.AddedBookmarks.Filter<MessageReceived>().Select(x => x.GetPayload<MessageReceivedStimulus>());
        await StartWorkersAsync(added, cancellationToken);
    }

    private async Task StartWorkersAsync(IEnumerable<MessageReceivedStimulus> payloads, CancellationToken cancellationToken)
    {
        foreach (var payload in payloads) await workerManager.StartWorkerAsync(payload.QueueOrTopic, payload.Subscription, cancellationToken);
    }
}