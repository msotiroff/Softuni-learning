namespace SoftUniClone.Tests.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniClone.Data;
    using System;

    public abstract class BaseServiceTest
    {
        protected BaseServiceTest()
        {
            TestSetup.Initialize();
        }
        
        protected SoftUniCloneDbContext Database
        {
            get
            {
                var options = new DbContextOptionsBuilder<SoftUniCloneDbContext>()
                   .UseInMemoryDatabase(Guid.NewGuid().ToString())
                   .Options;

                return new SoftUniCloneDbContext(options);
            }
        }
    }
}
