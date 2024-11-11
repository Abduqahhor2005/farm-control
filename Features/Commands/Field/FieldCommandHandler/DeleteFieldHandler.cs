using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Field.FieldCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FieldCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandHandler;

public class DeleteFieldHandler(IFieldCommandRepository fieldCommandRepository)
    :IRequestHandler<DeleteFieldRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteFieldRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Field?> existingFields = await fieldCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Field? existing = existingFields.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await fieldCommandRepository.UpdateAsync(existing.ToDeletedField());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Field not deleted !!!"))
            : BaseResult.Success();
    }
}