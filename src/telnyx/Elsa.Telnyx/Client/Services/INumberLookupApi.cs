using Elsa.Telnyx.Client.Models;
using Refit;

namespace Elsa.Telnyx.Client.Services;

public interface INumberLookupApi
{
    [Get("/v2/number_lookup/{phoneNumber}")]
    Task<TelnyxResponse<NumberLookupResponse>> NumberLookupAsync(
        string phoneNumber,
        [Query(CollectionFormat.Multi)] [AliasAs("type")]
        IEnumerable<string>? types = null,
        CancellationToken cancellationToken = default);
}