using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Field.FieldCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FieldCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandHandler;

public class CreateFieldHandler(IFieldCommandRepository fieldCommandRepository):IRequestHandler<CreateFieldRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateFieldRequest request, CancellationToken cancellationToken)
    {
        bool check = (await fieldCommandRepository.FindAsync(x =>
            x.Location.ToLower().Contains(request.FieldBaseInfo.Location.ToLower())
            && x.Area==request.FieldBaseInfo.Area)).Any();
        if (check)
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await fieldCommandRepository.AddAsync(request.ToField());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Field not saved !!!"))
            : BaseResult.Success();
    }
}