using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Chat:BaseEntity
{
    public string Comment { get; set; } = null!;
    public DateTimeOffset TalkTime { get; set; }
    public int FarmerId { get; set; } 
    public Farmer Farmer { get; set; } = null!;
    public int CustomerId { get; set; } 
    public Customer Customer { get; set; } = null!;
}