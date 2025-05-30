using Elsa.Features.Abstractions;
using Elsa.Features.Attributes;
using Elsa.Features.Services;
using Elsa.Scheduling.Hangfire.Services;
using Elsa.Workflows.Runtime;
using Elsa.Workflows.Runtime.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Scheduling.Hangfire.Features;

/// <summary>
/// Installs a Hangfire implementation for <see cref="IBackgroundActivityScheduler"/>.
/// </summary>
[DependsOn(typeof(WorkflowRuntimeFeature))]
public class HangfireBackgroundActivitySchedulerFeature : FeatureBase
{
    /// <inheritdoc />
    public HangfireBackgroundActivitySchedulerFeature(IModule module) : base(module)
    {
    }

    /// <inheritdoc />
    public override void Configure()
    {
        Module.Configure<WorkflowRuntimeFeature>(workflowRuntimeFeature =>
        {
            workflowRuntimeFeature.BackgroundActivityScheduler = sp => sp.GetRequiredService<HangfireBackgroundActivityScheduler>();
        });
    }

    /// <inheritdoc />
    public override void Apply()
    {
        Services.AddSingleton<HangfireBackgroundActivityScheduler>();
    }
}