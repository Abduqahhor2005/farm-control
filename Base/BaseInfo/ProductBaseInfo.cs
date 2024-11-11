namespace FarmControl.Base.BaseInfo;

public readonly record struct ProductBaseInfo(
    string Name,
    decimal Price,
    int QuantityAvailable,
    int FarmerId);