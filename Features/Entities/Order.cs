using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Order : BaseEntity
{
    public int Quantity { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public int ProductId { get; set; } 
    public Product Product { get; set; } = null!;
    public int CustomerId { get; set; } 
    public Customer Customer { get; set; } = null!;
}