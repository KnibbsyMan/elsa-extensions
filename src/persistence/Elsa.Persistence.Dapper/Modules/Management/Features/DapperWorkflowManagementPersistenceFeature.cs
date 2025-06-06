using Elsa.Persistence.Dapper.Extensions;
using Elsa.Persistence.Dapper.Features;
using Elsa.Persistence.Dapper.Modules.Management.Records;
using Elsa.Persistence.Dapper.Modules.Management.Stores;
using Elsa.Features.Abstractions;
using Elsa.Features.Attributes;
using Elsa.Features.Services;
using Elsa.Workflows.Management.Features;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Persistence.Dapper.Modules.Management.Features;

/// <summary>
/// Configures the <see cref="WorkflowInstancesFeature"/> and <see cref="WorkflowDefinitionsFeature"/> features with a Dapper persistence provider.
/// </summary>
[DependsOn(typeof(WorkflowManagementFeature))]
[DependsOn(typeof(WorkflowInstancesFeature))]
[DependsOn(typeof(WorkflowDefinitionsFeature))]
[DependsOn(typeof(DapperFeature))]
[PublicAPI]
public class DapperWorkflowManagementPersistenceFeature : FeatureBase
{
    /// <inheritdoc />
    public DapperWorkflowManagementPersistenceFeature(IModule module) : base(module)
    {
    }

    /// <inheritdoc />
    public override void Configure()
    {
        Module.Configure<WorkflowInstancesFeature>(feature => feature.WorkflowInstanceStore = sp => sp.GetRequiredService<DapperWorkflowInstanceStore>());
        Module.Configure<WorkflowDefinitionsFeature>(feature => feature.WorkflowDefinitionStore = sp => sp.GetRequiredService<DapperWorkflowDefinitionStore>());
    }

    /// <inheritdoc />
    public override void Apply()
    {
        base.Apply();
        
        Services.AddDapperStore<DapperWorkflowInstanceStore, WorkflowInstanceRecord>("WorkflowInstances");
        Services.AddDapperStore<DapperWorkflowDefinitionStore, WorkflowDefinitionRecord>("WorkflowDefinitions");
    }
}