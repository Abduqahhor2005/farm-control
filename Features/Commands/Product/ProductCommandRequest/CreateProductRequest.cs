using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandRequest;

public readonly record struct CreateProductRequest(
    ProductBaseInfo ProductBaseInfo):IRequest<BaseResult>;