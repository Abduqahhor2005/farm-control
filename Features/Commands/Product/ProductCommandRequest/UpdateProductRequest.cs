using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandRequest;

public readonly record struct UpdateProductRequest(
    int Id,
    ProductBaseInfo ProductBaseInfo):IRequest<BaseResult>;