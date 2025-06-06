using Elsa.Persistence.Elasticsearch.Contracts;
using Elsa.Features.Abstractions;
using Elsa.Features.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Persistence.Elasticsearch.Common;

/// <summary>
/// Base class for features that configure Elasticsearch persistence.
/// </summary>
public abstract class ElasticPersistenceFeatureBase : FeatureBase
{
    /// <inheritdoc />
    protected ElasticPersistenceFeatureBase(IModule module) : base(module)
    {
    }

    /// <summary>
    /// Registers an <see cref="ElasticStore{T}"/>.
    /// </summary>
    /// <typeparam name="TModel">The entity type of the store.</typeparam>
    /// <typeparam name="TStore">The type of the store.</typeparam>
    protected void AddStore<TModel, TStore>() where TModel : class where TStore : class
    {
        Services
            .AddScoped<ElasticStore<TModel>>()
            .AddScoped<TStore>();
    }

    /// <summary>
    /// Registers an <see cref="IIndexConfiguration"/>.
    /// </summary>
    protected void AddIndexConfiguration<TDocument>(Func<IServiceProvider, IIndexConfiguration<TDocument>> configuration) => Services.AddScoped<IIndexConfiguration>(configuration);
}