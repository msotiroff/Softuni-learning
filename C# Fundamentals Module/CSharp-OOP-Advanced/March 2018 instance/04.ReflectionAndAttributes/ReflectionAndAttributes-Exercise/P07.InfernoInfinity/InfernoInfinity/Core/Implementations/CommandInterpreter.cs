namespace InfernoInfinity.Core.Implementations
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Data.Contracts;
    using InfernoInfinity.Extensions.CustomAttributes;
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository<IWeapon> weaponRepository;
        private IFactory<IWeapon> weaponFactory;
        private IFactory<IGem> gemFactory;

        public CommandInterpreter(IRepository<IWeapon> weaponRepository, IFactory<IWeapon> weaponFactory, IFactory<IGem> gemFactory)
        {
            this.weaponRepository = weaponRepository;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public IExecutable InterpretCommand(string commandName, string[] commandParams)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IExecutable)))
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { commandParams });

            var instance = this.InjectDependencies(command);

            return instance;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            var neededDependencies = command
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(fi => fi.GetCustomAttributes()
                    .Any(attr => attr.GetType() == typeof(InjectAttribute)))
                .ToArray();

            foreach (var dependency in neededDependencies)
            {
                var dependencyToInject = this
                    .GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(fi => fi.Name == dependency.Name)?
                    .GetValue(this);

                dependency.SetValue(command, dependencyToInject);
            }

            return command;
        }
    }
}
