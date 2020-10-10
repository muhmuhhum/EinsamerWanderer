using System;

namespace EinsamerWanderer.Shared.Exception
{
    public class EntityNotFoundException : System.Exception
    {
        public string TypeName { get; set; }
        public Guid EntityId { get; set; }

        public EntityNotFoundException(string typeName, Guid entityId) : base()
        {
            TypeName = typeName;
            EntityId = entityId;
        }
    }
}