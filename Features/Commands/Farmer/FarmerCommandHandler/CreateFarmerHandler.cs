using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Farmer.FarmerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.FarmerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Farmer.FarmerCommandHandler;

public class CreateFarmerHandler(IFarmerCommandRepository farmerCommandRepository):IRequestHandler<CreateFarmerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateFarmerRequest request, CancellationToken cancellationToken)
    {
        bool check = (await farmerCommandRepository.FindAsync(x =>
            x.Email.ToLower().Contains(request.FarmerBaseInfo.Email.ToLower()))).Any();
        if (check)
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await farmerCommandRepository.AddAsync(request.ToFarmer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Farmer not saved !!!"))
            : BaseResult.Success();
    }
}