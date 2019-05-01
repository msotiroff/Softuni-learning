namespace FestivalManager
{
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using Entities.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
	{
		public static void Main(string[] args)
		{
            //FindAllMistakes();

            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();


            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            IFestivalController festivalController = new FestivalController(stage, setFactory, songFactory, performerFactory, instrumentFactory);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			IEngine engine = new Engine(setController, festivalController,reader, writer);

			engine.Run();
		}

        private static void FindAllMistakes()
        {
            // Return all classes, which contains non private fields:
            var classesWithPublicFields = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                        .Any(f => !f.IsPrivate))
                .Where(t => t.IsVisible)
                .ToArray();


            // Return all classes, which contains non private constants:
            var classesWithPublicConstants = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public)
                        .Where(fi => fi.IsLiteral && !fi.IsInitOnly && !fi.IsPrivate)
                            .Any())
                .Where(t => t.IsVisible)
                .ToArray();


            // Returnas all classes, which contains non public constructors:
            var classesWithNonPublicConstructors = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Any(ci => !ci.IsPublic)
                    && !t.IsAbstract)
                .ToArray();


            // Returnas all abstract classes, which contains non protected constructors:
            var abstractClassesWithNonProtectedConstructors = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Any(ci => !ci.IsFamily)
                    && t.IsAbstract)
                .ToArray();


            // Return all classes, which contains private properties:
            var classesWithPrivateProperties = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Any(pi => pi.GetMethod.IsPrivate))
                .ToArray();

            // Returns all classes, which contains public collections as properties, that are not readonly:
            var classesWithPublicNonReadonlyCollections = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetProperties()
                    .Any(pi => pi.PropertyType.IsGenericType
                        && (!pi.PropertyType.Name.Contains("ReadOnly")
                            || (pi.SetMethod != null && pi.SetMethod.IsPublic))))
                .ToArray();



            Console.ReadKey();
        }
    }
}