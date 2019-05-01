namespace LoggerSystem.Models.Factories
{
    using Common;
    using Contracts;
    using Implementations.Layouts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string typeName)
        {
            var layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(ILayout)))
                .FirstOrDefault(t => t.Name == typeName);

            if (layoutType == null)
            {
                throw new ArgumentException(ErrorMessages.InvalidLayout);
            }

            var instance = (ILayout)Activator.CreateInstance(layoutType);

            return instance;

            //ILayout layout = null;

            //switch (type)
            //{
            //    case nameof(JsonLayout):
            //        layout = new JsonLayout();
            //        break;
            //    case nameof(SimpleLayout):
            //        layout = new SimpleLayout();
            //        break;
            //    case nameof(XmlLayout):
            //        layout = new XmlLayout();
            //        break;
            //    default:
            //        throw new ArgumentException(ErrorMessages.InvalidLayout);
            //}

            //return layout;
        }
    }
}
