namespace SoftUniClone.Tests.Web.IdentityMocks
{
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using SoftUniClone.Models;

    public class UserManagerMock
    {
        public static Mock<UserManager<User>> Instance()
        {
            return new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        }
    }
}
