using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Farmer.FarmerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FarmerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Farmer.FarmerCommandHandler;

public class DeleteFarmerHandler(IFarmerCommandRepository farmerCommandRepository)
    :IRequestHandler<DeleteFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteFarmerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Farmer?> existingFarmers = await farmerCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Farmer? existing = existingFarmers.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await farmerCommandRepository.UpdateAsync(existing.ToDeletedFarmer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Farmer not deleted !!!"))
            : BaseResult.Success();
    }
}