namespace BashSoft.Tests
{
    using BashSoft.App.Extensions.CustomCollections;
    using BashSoft.App.Extensions.CustomCollections.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class OrderedDataStructureTester
    {
        private int DefaultCapacity = 16;
        private int DefaultSize = 0;

        private ISimpleSortedBag<string> names;
        
        [TestInitialize]
        public void InitializeCollection()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void JoinWithMethodWorksFine()
        {
            var joiner = ", ";
            var simpleData = new string[] { "Misho", "Pesho", "Gosho" };
            this.names.AddAll(simpleData);

            var expected = string.Join(joiner, simpleData.OrderBy(x => x));
            var real = this.names.JoinWith(joiner);

            Assert.AreEqual(expected, real);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JoinWithNullShouldThrowException()
        {
            var simpleData = new string[] { "Misho", "Pesho", "Gosho" };
            this.names.AddAll(simpleData);

            this.names.JoinWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingNullShouldThrowException()
        {
            this.names.Remove(null);
        }

        [TestMethod]
        public void RemoveValidElementRemovesSelectedOne()
        {
            var Misho = "Misho";
            var Pesho = "Pesho";

            this.names.Add(Misho);
            this.names.Add(Pesho);

            this.names.Remove(Pesho);

            Assert.IsFalse(this.names.Contains(Pesho));
        }

        [TestMethod]
        public void RemoveMethodShouldDecreasesSize()
        {
            const string First = "FirstElement";
            const string Second = "SecondElement";
            const string Third = "ThirdElement";

            var simpleData = new string[] { First, Second, Third };

            this.names.AddAll(simpleData);

            this.names.Remove(Second);

            Assert.AreEqual(this.names.Size, simpleData.Length - 1);
        }

        [TestMethod]
        public void AddAllMethodKeepsSortedData()
        {
            var Misho = "Misho";
            var Gosho = "Gosho";
            var Pesho = "Pesho";

            var unsortedElements = new string[] { Pesho, Misho, Gosho };
            var sortedElements = unsortedElements.OrderBy(x => x).ToArray();

            this.names.AddAll(unsortedElements);

            for (int i = 0; i < this.names.Size; i++)
            {
                Assert.AreEqual(sortedElements[i], this.names[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAllMethodShouldThrowExceptionWhenAddingNullValues()
        {
            var nullTestValues = new string[] { null, null, null };

            this.names.AddAll(nullTestValues);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var testValues = new string[2].Select(e => e = "SomeValue").ToArray();

            this.names.AddAll(testValues);

            Assert.AreEqual(this.names.Size, testValues.Length);
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            int TestSize = 17;

            var insertedData = (new string[TestSize])
                .Select(e => e = "SomeValue")
                .ToArray();

            this.names.AddAll(insertedData);

            Assert.AreEqual(names.Size, TestSize);
            Assert.AreNotEqual(this.names.Capacity, DefaultCapacity);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            string Rosen = "Rosen";
            string Georgi = "Georgi";
            string Balkan = "Balkan";
            
            this.names.Add(Rosen);
            this.names.Add(Georgi);
            this.names.Add(Balkan);

            var sortedData = new string[] { Balkan, Georgi, Rosen };

            for (int i = 0; i < sortedData.Length; i++)
            {
                Assert.AreEqual(this.names[i], sortedData[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMethodShoulThrowExceptionWhenAddingNullValue()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void AddMethodShoudIncreaseSize()
        {
            this.names.Add("Pesho");

            Assert.AreEqual(this.names.Size, 1);
        }

        [TestMethod]
        public void TestEmptyConstructor()
        {
            Assert.AreEqual(DefaultCapacity, names.Capacity);
            Assert.AreEqual(DefaultSize, names.Size);
        }

        [TestMethod]
        public void TestConstructorWithInitialCapacity()
        {
            int InitialCapacity = 20;
            int ExpectedCapacity = InitialCapacity;

            this.names = new SimpleSortedList<string>(InitialCapacity);

            Assert.AreEqual(ExpectedCapacity, names.Capacity);
            Assert.AreEqual(DefaultSize, names.Size);
        }

        [TestMethod]
        public void TestConstructorWithIComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(this.names.Size, DefaultSize);
            Assert.AreEqual(this.names.Capacity, DefaultCapacity);
        }

        [TestMethod]
        public void TestConstructorWithAllParameters()
        {
            int InitialCapacity = 30;

            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, InitialCapacity);

            Assert.AreEqual(this.names.Size, DefaultSize);
            Assert.AreEqual(this.names.Capacity, InitialCapacity);
        }
    }
}
