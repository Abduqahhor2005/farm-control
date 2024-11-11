using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Farmer.FarmerViewModels;

public readonly record struct GetFarmerViewModel(
    int Id,
    FarmerBaseInfo FarmerBaseInfo);

public record GetFarmerViewModelRequest(FarmerFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetFarmerViewModel>>>>;