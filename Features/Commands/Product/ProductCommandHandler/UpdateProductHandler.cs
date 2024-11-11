using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Product.ProductCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ProductCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandHandler;

public class UpdateProductHandler(IProductCommandRepository productCommandRepository):IRequestHandler<UpdateProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Product?> existingProducts = await productCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Product product = existingProducts.FirstOrDefault()!;
        if (product is null) return BaseResult.Failure(Error.None());

        int res = await productCommandRepository.UpdateAsync(product.ToUpdatedProduct(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Product not updated !!!"))
            : BaseResult.Success();
    }
}