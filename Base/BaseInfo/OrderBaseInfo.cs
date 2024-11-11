namespace FarmControl.Base.BaseInfo;

public readonly record struct OrderBaseInfo(
    int Quantity,
    DateTimeOffset OrderDate,
    int ProductId,
    int CustomerId);