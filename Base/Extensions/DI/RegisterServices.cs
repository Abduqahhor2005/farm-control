using System.Reflection;
using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Features.Repositories.CommandRepository.ChatCommandRepository;
using FarmControl.Features.Repositories.CommandRepository.CustomerCommandRepository;
using FarmControl.Features.Repositories.CommandRepository.FarmerCommandRepository;
using FarmControl.Features.Repositories.CommandRepository.FieldCommandRepository;
using FarmControl.Features.Repositories.CommandRepository.OrderCommandRepository;
using FarmControl.Features.Repositories.CommandRepository.ProductCommandRepository;
using FarmControl.Features.Repositories.QueryRepository.ChatQueryRepository;
using FarmControl.Features.Repositories.QueryRepository.CustomerQueryRepository;
using FarmControl.Features.Repositories.QueryRepository.FarmerQueryRepository;
using FarmControl.Features.Repositories.QueryRepository.FieldQueryRepository;
using FarmControl.Features.Repositories.QueryRepository.OrderQueryRepository;
using FarmControl.Features.Repositories.QueryRepository.ProductQueryRepository;

namespace FarmControl.Base.Extensions.DI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(ICommandGenericRepository<>), typeof(CommandGenericRepository<>));
        services.AddScoped<IChatCommandRepository, ChatCommandRepository>();
        services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
        services.AddScoped<IFarmerCommandRepository, FarmerCommandRepository>();
        services.AddScoped<IFieldCommandRepository, FieldCommandRepository>();
        services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped(typeof(IQueryGenericRepository<>), typeof(QueryGenericRepository<>));
        services.AddScoped<IChatQueryRepository, ChatQueryRepository>();
        services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        services.AddScoped<IFarmerQueryRepository, FarmerQueryRepository>();
        services.AddScoped<IFieldQueryRepository, FieldQueryRepository>();
        services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
        
        return services;
    }
}