using System;

namespace EinsamerWanderer.API.Model
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}