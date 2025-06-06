using Elsa.Features.Attributes;
using Elsa.Features.Services;
using Elsa.Workflows.Management.Entities;
using Elsa.Workflows.Management.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Persistence.EFCore.Modules.Management;

/// <summary>
/// Configures the <see cref="WorkflowDefinitionsFeature"/> feature with an Entity Framework Core persistence provider.
/// </summary>
[DependsOn(typeof(WorkflowManagementFeature))]
[DependsOn(typeof(WorkflowDefinitionsFeature))]
public class EFCoreWorkflowDefinitionPersistenceFeature(IModule module) : PersistenceFeatureBase<EFCoreWorkflowDefinitionPersistenceFeature, ManagementElsaDbContext>(module)
{
    /// <inheritdoc />
    public override void Configure()
    {
        Module.Configure<WorkflowDefinitionsFeature>(feature =>
        {
            feature.WorkflowDefinitionStore = sp => sp.GetRequiredService<EFCoreWorkflowDefinitionStore>();
        });
    }

    /// <inheritdoc />
    public override void Apply()
    {
        base.Apply();
        AddEntityStore<WorkflowDefinition, EFCoreWorkflowDefinitionStore>();
    }
}