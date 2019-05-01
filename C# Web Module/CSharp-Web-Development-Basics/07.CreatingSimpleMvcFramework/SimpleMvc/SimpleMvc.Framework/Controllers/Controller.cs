namespace SimpleMvc.Framework.Controllers
{
    using Interfaces;
    using Interfaces.Generic;
    using System.Runtime.CompilerServices;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName]string caller = "")
        {
            string controllerName = this.GetControllerName();

            var fullQualifiedName = this.GetFullQualifiedName(controllerName, caller);

            return new ActionResult(fullQualifiedName);
        }
        
        protected IActionResult View(string controller, string action)
        {
            var fullQualifiedName = this.GetFullQualifiedName(controller, action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            var controllerName = this.GetControllerName();

            var fullQualifiedName = this.GetFullQualifiedName(controllerName, caller);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            var fullQualifiedName = this.GetFullQualifiedName(controller, action);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }

        private string GetControllerName()
            => this.GetType()
                   .Name
                   .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        private string GetFullQualifiedName(string controllerName, string action)
            => string.Format("{0}.{1}.{2}.{3}, {0}",
                            MvcContext.Get.AssemblyName,
                            MvcContext.Get.ViewFolder,
                            controllerName,
                            action);
    }
}
