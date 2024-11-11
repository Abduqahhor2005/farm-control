using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Chat.ChatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Chat.ChatQueryHandler;

public class GetChatDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetChatDetailViewModelRequest, Result<GetChatDetailViewModel>>
{
    public async Task<Result<GetChatDetailViewModel>> Handle(GetChatDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Chat? result = await context.Chats.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetChatDetailViewModel>.Failure(Error.NotFound())
            : Result<GetChatDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}