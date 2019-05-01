namespace InfernoInfinity.Core.Implementations.Factories
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IFactory<IGem>
    {
        private const string InvalidClarity = "Invalid clarity!";
        private const string InvalidGem = "Invalid gem type!";

        public IGem CreateInstance(params string[] parameters)
        {
            // gemType, clarity

            var gemTypeName = parameters.First();
            Clarity clarity;
            if (!Enum.TryParse<Clarity>(parameters[1], out clarity))
            {
                throw new ArgumentException(InvalidClarity);
            }

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IGem)))
                .Where(t => !t.IsAbstract)
                .FirstOrDefault(t => t.Name == gemTypeName);

            if (type == null)
            {
                throw new ArgumentException(InvalidGem);
            }

            var instance = (IGem)Activator.CreateInstance(type, new object[] { clarity });

            return instance;
        }
    }
}
