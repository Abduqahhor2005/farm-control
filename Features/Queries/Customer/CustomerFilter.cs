using FarmControl.Base;

namespace FarmControl.Features.Queries.Customer;

public record CustomerFilter(
    string? FullName, 
    int? Age, 
    string? Email, 
    string? PhoneNumber, 
    string? Address):BaseFilter;