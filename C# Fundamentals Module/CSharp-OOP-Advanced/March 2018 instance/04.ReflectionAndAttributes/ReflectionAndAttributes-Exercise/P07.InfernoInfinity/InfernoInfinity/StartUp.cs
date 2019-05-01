namespace InfernoInfinity
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Core.Implementations;
    using InfernoInfinity.Core.Implementations.Factories;
    using InfernoInfinity.Data;
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.IO.Contracts;
    using InfernoInfinity.IO.Implementations;
    using InfernoInfinity.Models.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IRepository<IWeapon> weaponRepository = new WeaponRepository();
            IFactory<IWeapon> weaponFactory = new WeaponFactory();
            IFactory<IGem> gemFactory = new GemFactory();
            
            ICommandInterpreter commandInterpreter = new CommandInterpreter(weaponRepository, weaponFactory, gemFactory);

            IEngine engine = new Engine(commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}
