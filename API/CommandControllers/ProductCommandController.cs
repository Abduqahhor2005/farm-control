using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Product.ProductCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.CommandControllers;

[Route("/api/products")]
public class ProductCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteProductRequest(id));
        return result.ToActionResult();
    }
}