using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Product:BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int QuantityAvailable { get; set; }
    public int FarmerId { get; set; } 
    public Farmer Farmer { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = [];
}