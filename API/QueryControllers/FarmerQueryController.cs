using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Farmer;
using FarmControl.Features.Queries.Farmer.FarmerViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/farmers")]
public class FarmerQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FarmerFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetFarmerViewModel>>> response = await sender.Send(new GetFarmerViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetFarmerDetailViewModel> response = await sender.Send(new GetFarmerDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}