namespace SimpleMvc.Framework
{
    using System;
    using System.Reflection;
    using WebServer;

    public class MvcEngine
    {
        public void Run(HttpServer server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();

            try
            {
                server.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RegisterModelsData()
        {
            MvcContext.Get.ModelsFolder = "Models";
        }

        private void RegisterViewsData()
        {
            MvcContext.Get.ViewFolder = "Views";
        }

        private void RegisterControllersData()
        {
            MvcContext.Get.ControllersFolder = "Controllers";
            MvcContext.Get.ControllersSuffix = "Controller";
        }

        private void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly
                .GetEntryAssembly()
                .GetName()
                .Name;
        }
    }
}
