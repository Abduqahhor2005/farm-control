using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Field;
using FarmControl.Features.Queries.Field.FieldViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/fields")]
public class FieldQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FieldFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetFieldViewModel>>> response = await sender.Send(new GetFieldViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetFieldDetailViewModel> response = await sender.Send(new GetFieldDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}