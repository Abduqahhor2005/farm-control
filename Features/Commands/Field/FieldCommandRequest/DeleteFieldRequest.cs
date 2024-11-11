using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;

namespace FarmControl.Features.Commands.Field.FieldCommandRequest;

public readonly record struct DeleteFieldRequest(int Id):IRequest<BaseResult>;