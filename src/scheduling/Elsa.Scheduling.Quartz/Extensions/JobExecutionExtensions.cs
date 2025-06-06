using Elsa.Common.Multitenancy;
using Quartz;

namespace Elsa.Scheduling.Quartz;

internal static class JobExecutionExtensions
{
    public static async Task<Tenant?> GetTenantAsync(this IJobExecutionContext context, ITenantFinder tenantFinder)
    {
        if(!context.MergedJobDataMap.ContainsKey("TenantId"))
            return null;
        
        if(!context.MergedJobDataMap.TryGetString("TenantId", out var tenantId))
            return null;
        
        if (string.IsNullOrWhiteSpace(tenantId))
            return null;
        
        return await tenantFinder.FindByIdAsync(tenantId, context.CancellationToken);
    }
}