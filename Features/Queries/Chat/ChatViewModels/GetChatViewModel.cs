using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Chat.ChatViewModels;

public readonly record struct GetChatViewModel(
    int Id,
    ChatBaseInfo ChatBaseInfo);

public record GetChatViewModelRequest(ChatFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetChatViewModel>>>>;