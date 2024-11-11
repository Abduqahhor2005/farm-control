using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Field:BaseEntity
{
    public string Location { get; set; } = null!;
    public decimal Area { get; set; }
    public int FarmerId { get; set; }
    public Farmer Farmer { get; set; } = null!;
}