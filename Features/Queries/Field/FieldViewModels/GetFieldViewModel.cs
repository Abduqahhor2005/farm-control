using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Field.FieldViewModels;

public readonly record struct GetFieldViewModel(
    int Id,
    FieldBaseInfo FieldBaseInfo);

public record GetFieldViewModelRequest(FieldFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetFieldViewModel>>>>;