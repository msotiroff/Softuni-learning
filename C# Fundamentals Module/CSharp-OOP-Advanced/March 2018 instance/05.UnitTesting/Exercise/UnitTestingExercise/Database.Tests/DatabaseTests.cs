namespace Database.Tests
{
    using DataBase.Models;
    using NUnit.Framework;

    public class DatabaseTests
    {
        private const int DatabaseDefaultCapacity = 16;
        private Database database;
                
        [Test]
        public void TestConstructorWithValidParameters()
        {
            var inputParams = new long[] { 1, 2, 3, long.MaxValue, long.MinValue };

            var database = new Database(inputParams);

            for (int i = 0; i < inputParams.Length; i++)
            {
                var expected = inputParams[i];
                var actual = database[i];
                
                var errorMessage = "Database is not initialized properly";

                Assert.AreEqual(expected, actual, errorMessage);
            }
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenPassedMoreThanMaxCapacityElements()
        {
            var inputParams = new long[DatabaseDefaultCapacity + 1];
            var databaseOverflowErrorMessage = $"You cannot add more than {DatabaseDefaultCapacity} elements at the database!";

            Assert.That(() => new Database(inputParams), 
                    Throws.InvalidOperationException
                    .With
                    .Message
                    .EqualTo(databaseOverflowErrorMessage));
        }

        [TestCase(13)]
        [TestCase(long.MinValue)]
        [TestCase(long.MaxValue)]
        public void AddMethodShouldWorkProperly(long numberToAdd)
        {
            var database = new Database();

            database.Add(numberToAdd);

            var actual = database[0];
            var errorMessage = "Add method do not add elements properly";

            Assert.AreEqual(numberToAdd, actual, errorMessage);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTryingToAddElementInFullDatabase()
        {
            var inputElements = new long[DatabaseDefaultCapacity];

            var database = new Database(inputElements);

            var errorMessage = "Add method do not throws un exception, when database has overflow!";

            Assert.That(() => database.Add(13), Throws.InvalidOperationException, errorMessage);
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            var database = new Database(1, 2, 3);

            database.Remove();

            var actual = database[2];
            var errorMessage = "Remove method do not remove an element properly";

            Assert.AreEqual(default(long), actual, errorMessage);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenUsedOnEmptyDatabase()
        {
            var database = new Database();

            var errorMessage = "Remove method do not throws un exception when used over an empty database!";
            
            Assert.That(() => database.Remove(), Throws.InvalidOperationException, errorMessage);
        }

        [TestCase(new long[] { 1, 2, 3 })]
        [TestCase(new long[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 })]
        public void FetchMethodShouldReturnProperValues(long[] ctorArgs)
        {
            var database = new Database(ctorArgs);

            var actual = database.Fetch();

            var errorMessage = "Fetch method do not return the proper values!";

            Assert.AreEqual(ctorArgs, actual, errorMessage);
        }
    }
}
