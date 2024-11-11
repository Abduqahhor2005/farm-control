using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Chat.ChatCommandRequest;

public readonly record struct DeleteChatRequest(int Id):IRequest<BaseResult>;