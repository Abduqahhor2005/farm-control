using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Chat.ChatCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ChatCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Chat.ChatCommandHandler;

public class UpdateChatHandler(IChatCommandRepository chatCommandRepository):IRequestHandler<UpdateChatRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateChatRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Chat?> existingChats = await chatCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Chat chat = existingChats.FirstOrDefault()!;
        if (chat is null) return BaseResult.Failure(Error.None());

        int res = await chatCommandRepository.UpdateAsync(chat.ToUpdatedChat(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Chat not updated !!!"))
            : BaseResult.Success();
    }
}