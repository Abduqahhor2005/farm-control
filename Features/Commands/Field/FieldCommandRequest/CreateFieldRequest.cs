using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandRequest;

public readonly record struct CreateFieldRequest(
    FieldBaseInfo FieldBaseInfo):IRequest<BaseResult>;