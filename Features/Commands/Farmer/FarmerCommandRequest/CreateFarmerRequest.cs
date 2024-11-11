using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Farmer.FarmerCommandRequest;

public readonly record struct CreateFarmerRequest(
    FarmerBaseInfo FarmerBaseInfo):IRequest<BaseResult>;