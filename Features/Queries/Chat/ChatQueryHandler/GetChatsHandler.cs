using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Chat.ChatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Chat.ChatQueryHandler;

public class GetChatsHandler(AppQueryDbContext context) : IRequestHandler<GetChatViewModelRequest, Result<PagedResponse<IEnumerable<GetChatViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetChatViewModel>>>> Handle(GetChatViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Chat> chats = context.Chats;

        if (request.Filter!.TalkTime != null)
            chats = chats.Where(x => x.TalkTime==request.Filter.TalkTime);
        if (request.Filter!.FarmerId != null)
            chats = chats.Where(x => x.FarmerId==request.Filter.FarmerId);
        if (request.Filter!.CustomerId != null)
            chats = chats.Where(x => x.CustomerId==request.Filter.CustomerId);

        int count = await chats.CountAsync(cancellationToken);

        IQueryable<GetChatViewModel> result = chats
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetChatViewModel>> response = PagedResponse<IEnumerable<GetChatViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetChatViewModel>>>.Success(response);
    }
}