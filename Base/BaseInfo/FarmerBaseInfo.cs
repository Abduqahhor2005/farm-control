namespace FarmControl.Base.BaseInfo;

public readonly record struct FarmerBaseInfo(
    string FullName, 
    int Age, 
    string Email, 
    string PhoneNumber, 
    string Address);