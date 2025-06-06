using Elsa.Scripting.JavaScript.TypeDefinitions.Builders;
using Elsa.Scripting.JavaScript.TypeDefinitions.Contracts;
using Elsa.Scripting.JavaScript.TypeDefinitions.Models;
using Elsa.Secrets.Management;
using Humanizer;
using JetBrains.Annotations;

namespace Elsa.Secrets.Scripting.JavaScript;

[UsedImplicitly]
internal class SecretsTypeDefinitionProvider(ISecretManager secretManager) : ITypeDefinitionProvider, IVariableDefinitionProvider
{
    public async ValueTask<IEnumerable<TypeDefinition>> GetTypeDefinitionsAsync(TypeDefinitionContext context)
    {
        var cancellationToken = context.CancellationToken;
        var filter = new SecretFilter
        {
            Status = SecretStatus.Active
        };
        var secrets = await secretManager.FindManyAsync(filter, cancellationToken);
        
        var secretsContainerClass = new TypeDefinition
        {
            Name = "SecretVariables",
            DeclarationKeyword = "class"
        };

        foreach (var secret in secrets)
        {
            secretsContainerClass.Methods.Add(new FunctionDefinition
            {
                Name = $"get{secret.Name.Pascalize()}Async",
                ReturnType = "Promise<string>"
            });
        }
        
        return [secretsContainerClass];
    }
    
    public ValueTask<IEnumerable<VariableDefinition>> GetVariableDefinitionsAsync(TypeDefinitionContext context)
    {
        var definitions = new List<VariableDefinition>
        {
            new VariableDefinitionBuilder().Name("secrets").Type("SecretVariables").Build()
        };
            
                
        return new (definitions);
    }
}