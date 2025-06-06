namespace Elsa.ServiceBus.Kafka;

public interface ISchemaRegistryDefinitionProvider
{
    Task<IEnumerable<SchemaRegistryDefinition>> GetSchemaRegistryDefinitionsAsync(CancellationToken cancellationToken = default);
}