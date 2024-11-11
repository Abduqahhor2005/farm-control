using FarmControl.Base;

namespace FarmControl.Features.Queries.Chat;

public record ChatFilter(
    DateTimeOffset? TalkTime, 
    int? FarmerId, 
    int? CustomerId):BaseFilter;