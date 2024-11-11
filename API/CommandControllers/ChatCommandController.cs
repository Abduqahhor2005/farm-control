using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Chat.ChatCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.CommandControllers;

[Route("/api/chats")]
public class ChatCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChatRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateChatRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteChatRequest(id));
        return result.ToActionResult();
    }
}