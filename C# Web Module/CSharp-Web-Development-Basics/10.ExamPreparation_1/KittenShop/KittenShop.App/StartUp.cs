namespace KittenShop.App
{
    using AutoMapper;
    using Data;
    using Infrastructure;
    using KittenShop.App.Infrastructure.Extensions;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class StartUp
    {
        public static void Main()
        {
            ConfigureAutoMapper();
            var context = new KittenShopDbContext();
            context.AddDefaultBreeds();

            var server = new WebServer(8000, new ControllerRouter(), new ResourceRouter());
            
            MvcEngine.Run(server, context);
        }
        
        private static void ConfigureAutoMapper()
        {
            Mapper
                .Initialize(config =>
                    config.AddProfile<AutoMapperProfile>());
        }
    }
}
