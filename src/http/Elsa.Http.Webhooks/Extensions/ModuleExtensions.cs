using Elsa.Features.Services;
using Elsa.Http.Webhooks.Features;

// ReSharper disable once CheckNamespace
namespace Elsa.Extensions;

/// <summary>
/// Adds extensions to <see cref="IModule"/> that enables the <see cref="WebhooksFeature"/> feature.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Enables and configures the <see cref="WebhooksFeature"/> feature.
    /// </summary>
    public static IModule UseWebhooks(this IModule module, Action<WebhooksFeature>? configure = null)
    {
        module.Configure(configure);
        return module;
    }
}