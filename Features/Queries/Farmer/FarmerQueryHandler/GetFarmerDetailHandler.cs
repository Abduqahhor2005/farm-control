using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Farmer.FarmerViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Farmer.FarmerQueryHandler;

public class GetFarmerDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetFarmerDetailViewModelRequest, Result<GetFarmerDetailViewModel>>
{
    public async Task<Result<GetFarmerDetailViewModel>> Handle(GetFarmerDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Farmer? result = await context.Farmers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetFarmerDetailViewModel>.Failure(Error.NotFound())
            : Result<GetFarmerDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}