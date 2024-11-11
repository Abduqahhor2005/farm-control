using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Farmer.FarmerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FarmerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Farmer.FarmerCommandHandler;

public class UpdateFarmerHandler(IFarmerCommandRepository farmerCommandRepository):IRequestHandler<UpdateFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateFarmerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Farmer?> existingFarmers = await farmerCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Farmer farmer = existingFarmers.FirstOrDefault()!;
        if (farmer is null) return BaseResult.Failure(Error.None());
        
        bool check = (await farmerCommandRepository.FindAsync(x =>
            x.Email.ToLower().Contains(request.FarmerBaseInfo.Email.ToLower())
            || x.PhoneNumber==request.FarmerBaseInfo.PhoneNumber)).Any();
        if (check)
            return BaseResult.Failure(Error.AlreadyExist());

        int res = await farmerCommandRepository.UpdateAsync(farmer.ToUpdatedFarmer(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Farmer not updated !!!"))
            : BaseResult.Success();
    }
}