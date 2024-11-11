using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Customer:Person
{
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Chat> Chats { get; set; } = [];
}