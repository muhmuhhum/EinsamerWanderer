namespace EinsamerWanderer.API.RestContract.V1
{
    public partial class Routes
    {
        public partial class Item
        {
            public const string BaseRoute = "/api/v1";

            public const string Base = BaseRoute + "/item";
            public const string Get = Base + "/{itemId}";
            public const string GetAll = Base;
        }
    }
}