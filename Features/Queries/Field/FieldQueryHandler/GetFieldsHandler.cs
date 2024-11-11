using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Field.FieldViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Field.FieldQueryHandler;

public class GetFieldsHandler(AppQueryDbContext context) : IRequestHandler<GetFieldViewModelRequest, Result<PagedResponse<IEnumerable<GetFieldViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetFieldViewModel>>>> Handle(GetFieldViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Field> fields = context.Fields;

        if (request.Filter!.Location is not null)
            fields = fields.Where(x => x.Location.ToLower()
                .Contains(request.Filter.Location.ToLower()));
        if (request.Filter!.Area != null)
            fields = fields.Where(x => x.Area==request.Filter.Area);
        if (request.Filter!.FarmerId != null)
            fields = fields.Where(x => x.FarmerId==request.Filter.FarmerId);

        int count = await fields.CountAsync(cancellationToken);

        IQueryable<GetFieldViewModel> result = fields
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetFieldViewModel>> response = PagedResponse<IEnumerable<GetFieldViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetFieldViewModel>>>.Success(response);
    }
}