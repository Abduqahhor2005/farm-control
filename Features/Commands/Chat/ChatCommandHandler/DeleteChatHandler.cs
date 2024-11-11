using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Chat.ChatCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ChatCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Chat.ChatCommandHandler;

public class DeleteChatHandler(IChatCommandRepository chatCommandRepository)
    :IRequestHandler<DeleteChatRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteChatRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Chat?> existingChats = await chatCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Chat? existing = existingChats.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await chatCommandRepository.UpdateAsync(existing.ToDeletedChat());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Chat not deleted !!!"))
            : BaseResult.Success();
    }
}