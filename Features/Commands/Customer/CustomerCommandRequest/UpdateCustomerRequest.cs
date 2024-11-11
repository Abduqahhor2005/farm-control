using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Customer.CustomerCommandRequest;

public readonly record struct UpdateCustomerRequest(
    int Id,
    CustomerBaseInfo CustomerBaseInfo):IRequest<BaseResult>;