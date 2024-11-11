using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Farmer.FarmerCommandRequest;

public readonly record struct DeleteFarmerRequest(int Id):IRequest<BaseResult>;