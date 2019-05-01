namespace HTTPServer.ByTheCakeApplication
{
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/login");
            
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new ProductController().Add());

            appRouteConfig
                .Post("/add", req => new ProductController().Add(req.FormData));

            appRouteConfig
                .Get("/search", req => new ProductController().Search(req));

            appRouteConfig
                .Get("shopping/add", req => new ShoppingController().Add(req));

            appRouteConfig
                .Get("shopping/cart", req => new ShoppingController().CartDetails(req));

            appRouteConfig
                .Get("shopping/finish-order", req => new ShoppingController().FinishOrder(req));

            appRouteConfig
                .Get("/login", req => new AccountController().Login());

            appRouteConfig
                .Post("/login", req => new AccountController().Login(req));

            appRouteConfig
                .Get("/logout", req => new AccountController().Logout(req));
        }
    }
}
