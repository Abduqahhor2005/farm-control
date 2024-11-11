using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;
namespace FarmControl.Features.Queries.Field.FieldViewModels;

public readonly record struct GetFieldDetailViewModel(
    int Id,
    FieldBaseInfo FieldBaseInfo);
    
public record GetFieldDetailViewModelRequest(int Id) : IRequest<Result<GetFieldDetailViewModel>>;