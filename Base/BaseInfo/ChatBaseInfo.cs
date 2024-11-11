namespace FarmControl.Base.BaseInfo;

public readonly record struct ChatBaseInfo(
    string Comment, 
    DateTimeOffset TalkTime, 
    int FarmerId, 
    int CustomerId);