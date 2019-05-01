namespace MvcFramework
{
    using System;
    using System.Reflection;
    using WebServer;

    public class MvcEngine
    {
        public void Run(HttpServer server)
        {
            this.RegisterAssemblyName();
            this.RegisterControllersData();
            this.RegisterViewsData();
            this.RegisterModelsData();
            this.RegisterResoursesData();

            while (true)
            {
                try
                {
                    server.Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void RegisterResoursesData()
        {
            MvcContext.Get.ResoursesFolder = "..\\..\\..\\Resourses";
        }

        private void RegisterModelsData()
        {
            MvcContext.Get.ModelsFolder = "..\\..\\..\\Models";
        }

        private void RegisterViewsData()
        {
            MvcContext.Get.ViewsFolder = "..\\..\\..\\Views";
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
