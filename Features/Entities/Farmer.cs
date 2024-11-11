using FarmControl.Base.BaseEntities;

namespace FarmControl.Features.Entities;

public sealed class Farmer:Person
{
    public ICollection<Field> Fields { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<Chat> Chats { get; set; } = [];
}