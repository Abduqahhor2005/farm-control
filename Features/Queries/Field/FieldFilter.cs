using FarmControl.Base;

namespace FarmControl.Features.Queries.Field;

public record FieldFilter(
    string? Location,
    decimal? Area,
    int? FarmerId):BaseFilter;