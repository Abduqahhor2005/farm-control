using FarmControl.Features.Commands.Product.ProductCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Product.ProductViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class ProductMappingExtension
{
    public static GetProductViewModel ToReadInfo(this Product product)
    {
        return new()
        {
            Id = product.Id,
            ProductBaseInfo = new()
            {
                Name = product.Name,
                Price = product.Price,
                QuantityAvailable = product.QuantityAvailable,
                FarmerId = product.FarmerId
            }
        };
    }
    
    public static GetProductDetailViewModel ToReadDetailInfo(this Product product)
    {
        return new()
        {
            Id = product.Id,
            ProductBaseInfo = new()
            {
                Name = product.Name,
                Price = product.Price,
                QuantityAvailable = product.QuantityAvailable,
                FarmerId = product.FarmerId
            }
        };
    }

    public static Product ToProduct(this CreateProductRequest request)
    {
        return new()
        {
            Name = request.ProductBaseInfo.Name,
            Price = request.ProductBaseInfo.Price,
            QuantityAvailable = request.ProductBaseInfo.QuantityAvailable,
            FarmerId = request.ProductBaseInfo.FarmerId
        };
    }

    public static Product ToUpdatedProduct(this Product product, UpdateProductRequest request)
    {
        product.Version++;
        product.UpdatedAt = DateTime.UtcNow;
        product.Name = request.ProductBaseInfo.Name;
        product.Price = request.ProductBaseInfo.Price;
        product.QuantityAvailable = request.ProductBaseInfo.QuantityAvailable;
        product.FarmerId = request.ProductBaseInfo.FarmerId;
        return product;
    }

    public static Product ToDeletedProduct(this Product product)
    {
        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        product.Version++;
        return product;
    }
}