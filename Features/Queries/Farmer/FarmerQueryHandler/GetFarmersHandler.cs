using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Farmer.FarmerViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Farmer.FarmerQueryHandler;

public class GetFarmersHandler(AppQueryDbContext context) : IRequestHandler<GetFarmerViewModelRequest, Result<PagedResponse<IEnumerable<GetFarmerViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetFarmerViewModel>>>> Handle(GetFarmerViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Farmer> farmers = context.Farmers;

        if (request.Filter!.Age != null)
            farmers = farmers.Where(x => x.Age==request.Filter.Age);
        if (request.Filter.FullName is not null)
            farmers = farmers.Where(x => x.FullName.ToLower()
                .Contains(request.Filter.FullName.ToLower()));
        if (request.Filter.Email is not null)
            farmers = farmers.Where(x => x.Email.ToLower()
                .Contains(request.Filter.Email.ToLower()));
        if (request.Filter.PhoneNumber is not null)
            farmers = farmers.Where(x => x.PhoneNumber.ToLower()
                .Contains(request.Filter.PhoneNumber.ToLower()));
        if (request.Filter.Address is not null)
            farmers = farmers.Where(x => x.Address.ToLower()
                .Contains(request.Filter.Address.ToLower()));

        int count = await farmers.CountAsync(cancellationToken);

        IQueryable<GetFarmerViewModel> result = farmers
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetFarmerViewModel>> response = PagedResponse<IEnumerable<GetFarmerViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetFarmerViewModel>>>.Success(response);
    }
}