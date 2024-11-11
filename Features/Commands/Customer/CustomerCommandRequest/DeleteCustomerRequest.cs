using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Customer.CustomerCommandRequest;

public readonly record struct DeleteCustomerRequest(int Id):IRequest<BaseResult>;