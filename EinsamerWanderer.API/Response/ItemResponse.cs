using System;

namespace EinsamerWanderer.API.Response
{
    public class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}