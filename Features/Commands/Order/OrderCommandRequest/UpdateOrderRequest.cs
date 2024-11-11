using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Order.OrderCommandRequest;

public readonly record struct UpdateOrderRequest(
    int Id,
    OrderBaseInfo OrderBaseInfo):IRequest<BaseResult>;