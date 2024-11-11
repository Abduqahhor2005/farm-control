using FarmControl.Base;

namespace FarmControl.Features.Queries.Order;

public record OrderFilter(
    int? Quantity,
    DateTimeOffset? OrderDate,
    int? ProductId,
    int? CustomerId):BaseFilter;