using System;
using FluentAssertions;
using Kairos.Net.Models;
using NUnit.Framework;

namespace Kairos.Net.UnitTests
{
    [TestFixture]
    public class MinHeadScalesTests
    {
        [TestCase(0.014)]
        [TestCase(0.51)]
        public void Constructor_WithInvalidValue_ThrowsException(double value)
        {
            Action action = () => new MinHeadScale(value);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Convert_FromDouble_ReturnsMinHeadScaleInstance()
        {
            var value = 0.5;

            var minHeadScale = (MinHeadScale)value;

            minHeadScale.Value.Should().Be(value);
        }

        [Test]
        public void Convert_ToDouble_ReturnsCorrectValue()
        {
            var value = 0.5;
            var minHeadScale = new MinHeadScale(value);

            var result = (double)minHeadScale;

            result.Should().Be(value);
        }
    }
}
