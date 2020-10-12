using System;

namespace EinsamerWanderer.API.Model
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Experience { get; set; }
    }
}