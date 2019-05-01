namespace Notes.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var server = new HttpServer(8000, new ControllerRouter());

            var mvcEngine = new MvcEngine();

            mvcEngine.Run(server);
        }
    }
}
