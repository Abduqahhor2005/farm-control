namespace FarmControl.Base.BaseInfo;

public readonly record struct FieldBaseInfo(
    string Location,
    decimal Area,
    int FarmerId);