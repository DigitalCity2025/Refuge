using Refuge.Application.Enums;

namespace Refuge.Application.Entities
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CatColor Color { get; set; }
    }
}
