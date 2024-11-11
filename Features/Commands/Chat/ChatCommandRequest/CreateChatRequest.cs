using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Chat.ChatCommandRequest;

public readonly record struct CreateChatRequest(
    ChatBaseInfo ChatBaseInfo):IRequest<BaseResult>;