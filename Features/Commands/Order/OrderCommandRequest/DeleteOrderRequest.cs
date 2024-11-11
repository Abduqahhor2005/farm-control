using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Order.OrderCommandRequest;

public readonly record struct DeleteOrderRequest(int Id):IRequest<BaseResult>;