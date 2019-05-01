namespace ExtendedDataBase.Tests
{
    using ExtendedDataBase.Models;
    using NUnit.Framework;

    public class PersonTests
    {
        [Test]
        public void TestPersonConstructor()
        {
            var id = 13;
            var username = "Spartacus";

            var person = new Person(id, username);
            var errorMessage = "Constructor do not create the person properly.";

            Assert.That(() => person.Id == id && person.Username == username, errorMessage);
        }
    }
}
