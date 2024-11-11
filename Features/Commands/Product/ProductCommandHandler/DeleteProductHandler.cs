using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Product.ProductCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ProductCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Product.ProductCommandHandler;

public class DeleteProductHandler(IProductCommandRepository productCommandRepository)
    :IRequestHandler<DeleteProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Product?> existingProducts = await productCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Product? existing = existingProducts.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await productCommandRepository.UpdateAsync(existing.ToDeletedProduct());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Product not deleted !!!"))
            : BaseResult.Success();
    }
}