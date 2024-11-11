using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Field.FieldCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FieldCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandHandler;

public class UpdateFieldHandler(IFieldCommandRepository fieldCommandRepository):IRequestHandler<UpdateFieldRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateFieldRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Field?> existingFields = await fieldCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Field field = existingFields.FirstOrDefault()!;
        if (field is null) return BaseResult.Failure(Error.None());

        int res = await fieldCommandRepository.UpdateAsync(field.ToUpdatedField(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Field not updated !!!"))
            : BaseResult.Success();
    }
}