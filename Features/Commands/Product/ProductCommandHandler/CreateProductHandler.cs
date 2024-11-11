using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Product.ProductCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ProductCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandHandler;

public class CreateProductHandler(IProductCommandRepository productCommandRepository):IRequestHandler<CreateProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await productCommandRepository.AddAsync(request.ToProduct());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Product not saved !!!"))
            : BaseResult.Success();
    }
}