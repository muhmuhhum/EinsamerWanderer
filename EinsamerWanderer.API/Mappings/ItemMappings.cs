using AutoMapper;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Request;
using EinsamerWanderer.API.Response;

namespace EinsamerWanderer.API.Mappings
{
    public class ItemMappings : Profile
    {
        public ItemMappings()
        {
            CreateMap<CreateItemRequest, Item>();
            CreateMap<UpdateItemRequest, Item>();
            
            CreateMap<Item, ItemResponse>();
            CreateMap<Item, Item>();

        }
    }
}