using System;
using FluentAssertions;
using Kairos.Net.Models;
using NUnit.Framework;

namespace Kairos.Net.UnitTests
{
    [TestFixture]
    public class Base64ImageTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void Constructor_WithNullOrWhiteSpaceBase64String_ThrowsException(string base64String)
        {
            Action action = () => new Base64Image(base64String);

            action.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64String");
        }

        [Test]
        public void ToString_ReturnsValue()
        {
            var base64String = "base64";
            var base64Image = new Base64Image(base64String);

            var result = base64Image.ToString();

            result.Should().Be(base64String);
        }

        [Test]
        public void Conversion_FromString_ReturnsBase64ImageInstance()
        {
            var base64String = "base64";

            var base64Image = (Base64Image)base64String;

            base64Image.Value.Should().Be(base64String);
        }

        [Test]
        public void Conversion_ToString_ReturnsBase64ImageValue()
        {
            var base64String = "base64";
            var base64Image = new Base64Image(base64String);

            string result = base64Image;

            result.Should().Be(base64String);
        }
    }
}
