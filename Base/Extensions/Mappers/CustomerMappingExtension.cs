using FarmControl.Features.Commands.Customer.CustomerCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Customer.CustomerViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class CustomerMappingExtension
{
    public static GetCustomerViewModel ToReadInfo(this Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            CustomerBaseInfo = new()
            {
                FullName = customer.FullName,
                Age = customer.Age,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            }
        };
    }
    
    public static GetCustomerDetailViewModel ToReadDetailInfo(this Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            CustomerBaseInfo = new()
            {
                FullName = customer.FullName,
                Age = customer.Age,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            }
        };
    }

    public static Customer ToCustomer(this CreateCustomerRequest request)
    {
        return new()
        {
            FullName = request.CustomerBaseInfo.FullName,
            Age = request.CustomerBaseInfo.Age,
            Email = request.CustomerBaseInfo.Email,
            PhoneNumber = request.CustomerBaseInfo.PhoneNumber,
            Address = request.CustomerBaseInfo.Address
        };
    }

    public static Customer ToUpdatedCustomer(this Customer customer, UpdateCustomerRequest request)
    {
        customer.Version++;
        customer.UpdatedAt = DateTime.UtcNow;
        customer.FullName = request.CustomerBaseInfo.FullName;
        customer.Age = request.CustomerBaseInfo.Age;
        customer.Email = request.CustomerBaseInfo.Email;
        customer.PhoneNumber = request.CustomerBaseInfo.PhoneNumber;
        customer.Address = request.CustomerBaseInfo.Address;
        return customer;
    }

    public static Customer ToDeletedCustomer(this Customer customer)
    {
        customer.IsDeleted = true;
        customer.DeletedAt = DateTime.UtcNow;
        customer.UpdatedAt = DateTime.UtcNow;
        customer.Version++;
        return customer;
    }
}