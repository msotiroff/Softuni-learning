namespace MathClass.Tests
{
    using NUnit.Framework;
    using System;

    public class MathTests
    {
        [TestCase(-1, 1)]
        [TestCase(-1.5, 1.5)]
        [TestCase(-2147483647, 2147483647)]
        public void AbsoluteMethodShouldReturnPositiveValue(double input, double expected)
        {
            var actual = Math.Abs(input);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(9.3, 9)]
        [TestCase(1.99, 1)]
        [TestCase(0.999999999, 0)]
        [TestCase(-2.5, -3)]
        public void FloorMethodShouldReturnExpectedValue(double input, double expected)
        {
            var actual = Math.Floor(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
