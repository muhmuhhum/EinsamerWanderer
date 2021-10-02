using System;

namespace EinsamerWanderer.Shared.Request
{
    public class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}