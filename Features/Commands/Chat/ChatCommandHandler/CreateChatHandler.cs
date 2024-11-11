using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Chat.ChatCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.ChatCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Chat.ChatCommandHandler;

public class CreateChatHandler(IChatCommandRepository chatCommandRepository):IRequestHandler<CreateChatRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateChatRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await chatCommandRepository.AddAsync(request.ToChat());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Chat not saved !!!"))
            : BaseResult.Success();
    }
}