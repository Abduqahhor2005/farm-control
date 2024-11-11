using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Field.FieldViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Field.FieldQueryHandler;

public class GetFieldDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetFieldDetailViewModelRequest, Result<GetFieldDetailViewModel>>
{
    public async Task<Result<GetFieldDetailViewModel>> Handle(GetFieldDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Field? result = await context.Fields.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetFieldDetailViewModel>.Failure(Error.NotFound())
            : Result<GetFieldDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}