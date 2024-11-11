using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Chat;
using FarmControl.Features.Queries.Chat.ChatViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/chats")]
public class ChatQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ChatFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetChatViewModel>>> response = await sender.Send(new GetChatViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetChatDetailViewModel> response = await sender.Send(new GetChatDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}