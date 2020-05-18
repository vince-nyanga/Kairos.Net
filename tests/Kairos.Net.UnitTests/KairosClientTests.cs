using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kairos.Net.Models;
using NUnit.Framework;

namespace Kairos.Net.UnitTests
{
    [TestFixture]
    public class KairosClientTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void Constructor_WithNullOrWhiteSpaceAppId_ThrowsException(string appId)
        {
            Action action = () => new KairosClient(appId, "apiKey");

            action.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("appId");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void Constructor_WithNullOrWhiteSpaceApiKey_ThrowsException(string apiKey)
        {
            Action action = () => new KairosClient("appId", apiKey);

            action.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("apiKey");
        }

        [Test]
        public void EnrollImageAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Base64Image)null, "subject","gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_Base64Overload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Base64Image)"base64", subjectId, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_Base64Overload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Base64Image)"base64", "subject", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void EnrollImageAsync_WithNullUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Uri)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_UriOverload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                subjectId,
                "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_UriOverload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "subject",
                galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void VerifyImageAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync((Base64Image)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyImageAsync_Base64Overload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync((Base64Image)"base64", subjectId, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyImageAsync_Base64Overload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync((Base64Image)"base64", "subject", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void VerifyImageAsync_WithNullUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync((Uri)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyImageAsync_UriOverload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                subjectId,
                "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyImageAsync_UriOverload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyImageAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "subject",
                galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        private KairosClient CreateClient()
        {
            return new KairosClient("fakeAppId", "fakeApiKey");
        }
    }
}
