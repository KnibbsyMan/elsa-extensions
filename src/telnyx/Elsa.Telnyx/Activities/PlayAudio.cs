﻿using System.Runtime.CompilerServices;
using Elsa.Workflows;
using Elsa.Workflows.Attributes;
using JetBrains.Annotations;

namespace Elsa.Telnyx.Activities;

/// <inheritdoc />
[PublicAPI]
public class PlayAudio : PlayAudioBase
{
    /// <inheritdoc />
    public PlayAudio([CallerFilePath] string? source = null, [CallerLineNumber] int? line = null) : base(source, line)
    {
    }

    /// <summary>
    /// The <see cref="IActivity"/> to execute when the call was no longer active.
    /// </summary>
    [Port] public IActivity? Disconnected { get; set; }

    /// <inheritdoc />
    protected override async ValueTask HandlePlaybackStartedAsync(ActivityExecutionContext context) => await context.CompleteActivityAsync();

    /// <inheritdoc />
    protected override async ValueTask HandleDisconnectedAsync(ActivityExecutionContext context) => await context.ScheduleActivityAsync(Disconnected, OnCompletedAsync);

    private async ValueTask OnCompletedAsync(ActivityCompletedContext context) => await context.TargetContext.CompleteActivityAsync();
}