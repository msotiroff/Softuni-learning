using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SoftUniClone.Tests.Web.Controllers
{
    public abstract class BaseControllerTest
    {
        protected BaseControllerTest()
        {
            TestSetup.Initialize();
        }

        protected ControllerContext ControllerContext
        {
            get
            {
                return new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(
                        new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, "username")
                        }, "someAuthTypeName"))
                    }
                };
            }
        }
    }
}
