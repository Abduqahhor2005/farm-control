using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandRequest;

public readonly record struct DeleteProductRequest(int Id):IRequest<BaseResult>;