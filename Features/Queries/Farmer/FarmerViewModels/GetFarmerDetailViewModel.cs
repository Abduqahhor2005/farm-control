using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;
namespace FarmControl.Features.Queries.Farmer.FarmerViewModels;

public readonly record struct GetFarmerDetailViewModel(
    int Id,
    FarmerBaseInfo FarmerBaseInfo);
    
public record GetFarmerDetailViewModelRequest(int Id) : IRequest<Result<GetFarmerDetailViewModel>>;