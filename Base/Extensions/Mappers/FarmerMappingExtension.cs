using FarmControl.Features.Commands.Farmer.FarmerCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Farmer.FarmerViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class FarmerMappingExtension
{
    public static GetFarmerViewModel ToReadInfo(this Farmer farmer)
    {
        return new()
        {
            Id = farmer.Id,
            FarmerBaseInfo = new()
            {
                FullName = farmer.FullName,
                Age = farmer.Age,
                Email = farmer.Email,
                PhoneNumber = farmer.PhoneNumber,
                Address = farmer.Address
            }
        };
    }
    
    public static GetFarmerDetailViewModel ToReadDetailInfo(this Farmer farmer)
    {
        return new()
        {
            Id = farmer.Id,
            FarmerBaseInfo = new()
            {
                FullName = farmer.FullName,
                Age = farmer.Age,
                Email = farmer.Email,
                PhoneNumber = farmer.PhoneNumber,
                Address = farmer.Address
            }
        };
    }

    public static Farmer ToFarmer(this CreateFarmerRequest request)
    {
        return new()
        {
            FullName = request.FarmerBaseInfo.FullName,
            Age = request.FarmerBaseInfo.Age,
            Email = request.FarmerBaseInfo.Email,
            PhoneNumber = request.FarmerBaseInfo.PhoneNumber,
            Address = request.FarmerBaseInfo.Address
        };
    }

    public static Farmer ToUpdatedFarmer(this Farmer farmer, UpdateFarmerRequest request)
    {
        farmer.Version++;
        farmer.UpdatedAt = DateTime.UtcNow;
        farmer.FullName = request.FarmerBaseInfo.FullName;
        farmer.Age = request.FarmerBaseInfo.Age;
        farmer.Email = request.FarmerBaseInfo.Email;
        farmer.PhoneNumber = request.FarmerBaseInfo.PhoneNumber;
        farmer.Address = request.FarmerBaseInfo.Address;
        return farmer;
    }

    public static Farmer ToDeletedFarmer(this Farmer farmer)
    {
        farmer.IsDeleted = true;
        farmer.DeletedAt = DateTime.UtcNow;
        farmer.UpdatedAt = DateTime.UtcNow;
        farmer.Version++;
        return farmer;
    }
}