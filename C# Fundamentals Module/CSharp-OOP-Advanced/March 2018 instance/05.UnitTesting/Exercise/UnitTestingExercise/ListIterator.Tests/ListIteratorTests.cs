namespace ListIterator.Tests
{
    using NUnit.Framework;
    using ListIterator.Models;

    public class ListIteratorTests
    {
        private string[] initialData;
        private ListIterator listIterator;

        [SetUp]
        public void SetInitialData()
        {
            this.initialData = new string[]
            {
                "Hephaestus",
                "Zeus",
                "Hermes"
            };

            this.listIterator = new ListIterator(initialData);
        }

        [Test]
        public void ConstructorShouldSetDataProperly()
        {
            var errorMsg = "Constructor does not work properly!";

            Assert.That(() => this.listIterator.Items.Count == 3, errorMsg);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfParameterIsNull()
        {
            var errorMsg = "Constructor did not throw proper exception!";

            Assert.That(() => new ListIterator(null),
                Throws.ArgumentNullException,
                errorMsg);
        }

        [Test]
        public void HasNextMethodShouldReturnTrue()
        {
            Assert.IsTrue(this.listIterator.HasNext());
        }

        [Test]
        public void HasNextMethodShouldReturnFalse()
        {
            this.listIterator = new ListIterator(new string[] { "Poseidon" });

            Assert.IsFalse(this.listIterator.HasNext());
        }

        [Test]
        public void PrintMethodShouldThrowExceptionIfCollectionEmpty()
        {
            this.listIterator = new ListIterator(new string[] { });
            var errorMsg = "Method did not throw a proper exception!";

            Assert.That(() => this.listIterator.Print(),
                Throws.InvalidOperationException,
                errorMsg);
        }

        [Test]
        public void PrintMethodShoudWorkProperly()
        {
            var expected = this.initialData[0];
            var actual = this.listIterator.Print();
            var errorMsg = "Method did not return the proper value";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void MoveMethodShouldReturnTrue()
        {
            Assert.IsTrue(this.listIterator.Move());
        }

        [Test]
        public void MoveMethodShouldReturnFalse()
        {
            this.listIterator = new ListIterator(new string[] { "Hephaestus" });

            Assert.IsFalse(this.listIterator.Move());
        }

        [Test]
        public void MoveMethodShouldIncreaseCurrentIndex()
        {
            this.listIterator.Move();

            var expected = this.initialData[1];
            var actual = this.listIterator.Items[1];
            var errorMsg = "Method did not return the proper value";
            
            Assert.AreEqual(expected, actual, errorMsg);
        }
    }
}
