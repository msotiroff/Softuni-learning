namespace CustomLinkedList.Tests
{
    using NUnit.Framework;
    using System;

    public class DynamicListTests
    {
        private DynamicList<int> list;

        [SetUp]
        public void InitializeList()
        {
            this.list = new DynamicList<int>();

            this.list.Add(1);
            this.list.Add(2);
            this.list.Add(3);
            this.list.Add(4);
            this.list.Add(5);
        }

        [Test]
        public void TestConstructor()
        {
            var someList = new DynamicList<string>();
            var errorMsg = "Constructor does not work properly!";

            Assert.IsInstanceOf<DynamicList<string>>(someList, errorMsg);
        }

        [Test]
        public void CountMethodShouldReturnZero()
        {
            this.list = new DynamicList<int>();
            var expected = 0;
            var actual = this.list.Count;

            var errorMsg = $"Count method did not return correct value. Expected: {expected}, Actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void CountMethodShouldReturnCorrectValue()
        {
            var expected = 5;
            var actual = this.list.Count;
            var errorMsg = $"Count method did not return correct value. Expected: {expected}, Actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void IndexerShouldThrowExceptionIfIndexIsInavalid(int index)
        {
            var errorMsg = "Method did not throw the expected exception!";

            Assert.That(() => this.list[index],
                Throws.InstanceOf<ArgumentOutOfRangeException>(),
                errorMsg);
        }

        [TestCase(0)]
        [TestCase(2)]
        public void IndexerShouldReturnTheProperValue(int index)
        {
            var expected = index + 1;
            var actual = this.list[index];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            var expected = this.list.Count + 1;
            this.list.Add(10);

            var actual = this.list.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(1000)]
        public void RemoveAtMethodShouldThrowExceptionIfIndexIsInvalid(int index)
        {
            var errorMsg = "Method did not throw the expected exception!";

            Assert
                .Throws<ArgumentOutOfRangeException>(() => 
                    this.list.RemoveAt(index),
                    errorMsg);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveAtShouldRemoveTheExactElement(int index)
        {
            var expected = this.list[index];
            var actual = this.list.RemoveAt(index);
            var errorMsg = "Method did not remove the proper element!";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(200, -1)]
        [TestCase(-20, -1)]
        public void RemoveMethodShouldReturnDefaultIndex(int element, int expected)
        {
            var actual = this.list.Remove(element);
            var errorMsg = $"Method did not return the proper index. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(1, 0)]
        [TestCase(3, 2)]
        public void RemoveMethodShouldReturnProperValue(int element, int expected)
        {
            var actual = this.list.Remove(element);
            var errorMsg = $"Method did not return the proper index. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(15)]
        [TestCase(215)]
        public void IndexOfMethodShouldReturnDefaultValue(int element)
        {
            var expected = -1;
            var actual = this.list.IndexOf(element);
            var errorMsg = $"Method did not return the proper index. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(1, 0)]
        [TestCase(3, 2)]
        public void IndexOfMethodShouldReturnProperValue(int element, int expected)
        {
            var actual = this.list.IndexOf(element);
            var errorMsg = $"Method did not return the proper index. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void ContainsMethodShouldReturnTrue(int element)
        {
            var actual = this.list.Contains(element);
            var errorMsg = "Method did not return proper condition";

            Assert.IsTrue(actual, errorMsg);
        }

        [TestCase(100)]
        [TestCase(300)]
        [TestCase(500)]
        public void ContainsMethodShouldReturnFalse(int element)
        {
            var actual = this.list.Contains(element);
            var errorMsg = "Method did not return proper condition";

            Assert.IsFalse(actual, errorMsg);
        }
    }
}
