using FarmControl.Base;

namespace FarmControl.Features.Queries.Farmer;

public record FarmerFilter(
    string? FullName, 
    int? Age, 
    string? Email, 
    string? PhoneNumber, 
    string? Address):BaseFilter;