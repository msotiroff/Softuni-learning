namespace ByTheCake.App
{
    using ByTheCake.App.Controllers;
    using HTTPServer.Contracts;
    using HTTPServer.Routing.Contracts;

    public class ByTheCakeAppConfiguration : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            #region AnonymousRoutes
            appRouteConfig.AnonymousPaths.Add("/login");
            appRouteConfig.AnonymousPaths.Add("/register");
            #endregion
            
            #region HomeControllerRoutes
            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());
            #endregion

            #region ProductControllerRoutes
            appRouteConfig
                .Get("/add", req => new ProductController().Add());

            appRouteConfig
                .Post("/add", req => new ProductController().Add(req.FormData).Result);

            appRouteConfig
                .Get("/search", req => new ProductController().Search(req));

            appRouteConfig
                .Get("product/details", req => new ProductController().Details(req.UrlParameters).Result);
            #endregion

            #region ShoppingControllerRoutes
            appRouteConfig
                .Get("shopping/add", req => new ShoppingController().AddToCart(req).Result);

            appRouteConfig
                .Get("shopping/cart", req => new ShoppingController().CartDetails(req));

            appRouteConfig
                .Get("shopping/finish-order", req => new ShoppingController().FinishOrder(req).Result);

            appRouteConfig
                .Get("/orders", req => new ShoppingController().UserOrders(req).Result);

            appRouteConfig
                .Get("orderDetails", req => new ShoppingController().OrderDetails(req.UrlParameters).Result);
            #endregion

            #region AccountControllerRoutes
            appRouteConfig
                .Get("/login", req => new AccountController().Login());

            appRouteConfig
                .Post("/login", req => new AccountController().Login(req).Result);

            appRouteConfig
                .Get("/logout", req => new AccountController().Logout(req));

            appRouteConfig
                .Get("/register", req => new AccountController().Register());

            appRouteConfig
                .Post("/register", req => new AccountController().Register(req).Result);

            appRouteConfig
                .Get("/profile", req => new AccountController().Profile(req.Session).Result);
            #endregion
        }
    }
}
