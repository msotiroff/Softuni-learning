namespace ModPanel.App.Infrastructure.Attributes
{
    using SimpleMvc.Framework.Attributes.Security;
    using System;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthorizedOnlyAttribute : PreAuthorizeAttribute
    {
        public override IHttpResponse GetResponse(string message)
        {
            return new RedirectResponse("/account/login");
        }
    }
}
