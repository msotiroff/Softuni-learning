namespace ExtendedDataBase.Tests
{
    using ExtendedDataBase.Models;
    using NUnit.Framework;
    using System;

    public class ExtendedDatabaseTests
    {
        private Person[] testingPeople;
        private Database database;

        [SetUp]
        public void InitializeData()
        {
            this.testingPeople = new Person[]
            {
                new Person(1, "Spartacus"),
                new Person(2, "Achilles"),
                new Person(3, "Perseus")
            };

            database = new Database(testingPeople);
        }

        [Test]
        public void TestDatabaseConstructor()
        {
            for (int i = 0; i < testingPeople.Length; i++)
            {
                var expected = testingPeople[i];
                var actual = database[i];
                var errorMessage = "Constructor does not initialize database properly!";

                Assert.AreEqual(expected, actual, errorMessage);
            }
        }

        [Test]
        public void TestAddMethodWithValidPerson()
        {
            var person = new Person(5, "Menelaus");

            database.Add(person);
            var errorMessage = "Person has not been added to database.";

            Assert.AreEqual(person, database[3], errorMessage);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfArgumentUsernameIsDuplicated()
        {
            var person = new Person(5, "Spartacus");
            var errorMessage = "Add method does not throw the proper exception!";

            Assert.That(() => this.database.Add(person), 
                Throws.InvalidOperationException, 
                errorMessage);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfArgumentIdIsDuplicated()
        {
            var person = new Person(1, "Aiantos");
            var errorMessage = "Add method does not throw the proper exception!";

            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException,
                errorMessage);
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            this.database.Remove();

            var errorMessage = "Remove method does not remove an element!";
            int actual = this.database.Count;
            int expected = this.testingPeople.Length - 1;

            Assert.AreEqual(expected, actual, errorMessage);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCalledOverEmptyDatabase()
        {
            this.database = new Database();
            var errorMessage = "Remove method does not throw a proper exception!";

            Assert.That(() => this.database.Remove(), 
                Throws.InvalidOperationException, 
                errorMessage);
        }

        [TestCase("Spartacus")]
        [TestCase("Achilles")]
        [TestCase("Perseus")]
        public void FindByUsernameMethodShouldWorkProperly(string username)
        {
            var errorMessage = $"Username {username} not found!";
            var result = this.database.FindByUsername(username)?.Username;

            Assert.AreEqual(username, result, errorMessage);
        }

        [Test]
        public void FindByUsernameMethodShoudThrowExceptionWhenUserIsNotFound()
        {
            var username = "Eteokles";
            var errorMessage = "Method did not throw a proper exception!";

            Assert.That(() => this.database.FindByUsername(username), 
                Throws.InvalidOperationException, 
                errorMessage);
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfAgrumentIsNull()
        {
            var errorMessage = "Method did not throw a proper exception!";

            Assert.That(() => this.database.FindByUsername(null),
                Throws.ArgumentNullException,
                errorMessage);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FindByIdMethodShouldWorkProperly(long id)
        {
            var errorMessage = $"Person with Id {id} not found!";

            var result = this.database.FindById(id)?.Id;

            Assert.AreEqual(id, result, errorMessage);
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdNotFound()
        {
            var id = 123;
            var errorMessage = "Method did not throw a proper exception!";
            
            Assert.That(() => this.database.FindById(id),
                Throws.InvalidOperationException,
                errorMessage);
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdIsNegativeNumber()
        {
            var negativeId = -1;
            var errorMessage = "Method did not throw a proper exception!";

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    this.database.FindById(negativeId),
                    errorMessage);
        }
    }
}
