using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kairos.Net.Interfaces;
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
        public void Constructor_WithNullOrWhiteSpaceAppKey_ThrowsException(string appKey)
        {
            Action action = () => new KairosClient("appId", appKey);

            action.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("appKey");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void Constructor_WithNullOrWhiteSpaceBaseUrl_ThrowsException(string baseUrl)
        {
            Action action = () => new KairosClient("appId", "apiKey",baseUrl);

            action.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("baseUrl");
        }

        [Test]
        public void EnrollFaceAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync((Base64Image)null, "subject","gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollFaceAsync_Base64Overload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync((Base64Image)"base64", subjectId, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollFaceAsync_Base64Overload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync((Base64Image)"base64", "subject", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void EnrollFaceAsync_WithNullUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync((Uri)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollFaceAsync_UriOverload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                subjectId,
                "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollFaceAsync_UriOverload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "subject",
                galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void VerifyFaceAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync((Base64Image)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyFaceAsync_Base64Overload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync((Base64Image)"base64", subjectId, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyFaceAsync_Base64Overload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync((Base64Image)"base64", "subject", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void VerifyFaceAsync_WithNullUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync((Uri)null, "subject", "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyFaceAsync_UriOverload_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                subjectId,
                "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void VerifyFaceAsync_UriOverload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.VerifyFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "subject",
                galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void RecognizeFaceAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.RecognizeFaceAsync((Base64Image)null,"gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

    
        [TestCase(null)]
        [TestCase("")]
        public void RecognizeFaceAsync_Base64Overload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.RecognizeFaceAsync((Base64Image)"base64", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void RecognizeFaceAsync_WithNullUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.RecognizeFaceAsync((Uri)null, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }


        [TestCase(null)]
        [TestCase("")]
        public void RecognizeFaceAsync_UriOverload_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.RecognizeFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [Test]
        public void DetectFacesAsync_WithNullBase64Image_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.DetectFacesAsync((Base64Image)null);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [Test]
        public void DetectFacesAsync_WithNullImageUri_ThrowsException()
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.DetectFacesAsync((Uri)null);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("imageUri");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void ListFacesAsync_WithNullOrWhiteSpaceGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.ListFacesAsync(galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("\t")]
        public void RemoveGalleryAsync_WithNullOrWhiteSpaceGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.RemoveGalleryAsync(galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        private IKairosClient CreateClient()
        {
            return new KairosClient("fakeAppId", "fakeApiKey");
        }
    }
}
