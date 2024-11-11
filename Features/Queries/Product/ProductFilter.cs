using FarmControl.Base;

namespace FarmControl.Features.Queries.Product;

public record ProductFilter(
    string? Name,
    decimal? Price,
    int? QuantityAvailable,
    int? FarmerId):BaseFilter;