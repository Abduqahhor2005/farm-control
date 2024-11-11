using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Product;
using FarmControl.Features.Queries.Product.ProductViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/products")]
public class ProductQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetProductViewModel>>> response = await sender.Send(new GetProductViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetProductDetailViewModel> response = await sender.Send(new GetProductDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}