using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Queries.Chat.ChatViewModels;

public readonly record struct GetChatDetailViewModel(
    int Id,
    ChatBaseInfo ChatBaseInfo);
    
public record GetChatDetailViewModelRequest(int Id) : IRequest<Result<GetChatDetailViewModel>>;    