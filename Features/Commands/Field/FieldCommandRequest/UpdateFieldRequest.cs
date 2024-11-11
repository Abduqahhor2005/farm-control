using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandRequest;

public readonly record struct UpdateFieldRequest(
    int Id,
    FieldBaseInfo FieldBaseInfo):IRequest<BaseResult>;