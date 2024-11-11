namespace FarmControl.Base.BaseInfo;

public readonly record struct CustomerBaseInfo(
    string FullName, 
    int Age, 
    string Email, 
    string PhoneNumber, 
    string Address);