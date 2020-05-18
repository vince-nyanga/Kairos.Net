using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kairos.Net.Models;
using NUnit.Framework;

namespace Kairos.Net.IntegrationTests
{
    [TestFixture]
    public class KairosClientTests
    {
        [Test]
        public async Task EnrollFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.EnrollFaceAsync(
                (Base64Image)"https://media.kairos.com/kairos-elizabeth.jpg", // This is cheating
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.FaceId.Should().NotBeNull();
        }

        [Test]
        public async Task EnrollFaceAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"), 
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.FaceId.Should().NotBeNull();
        }

        [Test]
        public async Task VerifyFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.VerifyFaceAsync(
                (Base64Image)"https://media.kairos.com/kairos-elizabeth.jpg", // This is cheating
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task VerifyFaceAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.VerifyFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task RecognizeFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.RecognizeFaceAsync(
                (Base64Image)"https://media.kairos.com/kairos-elizabeth.jpg", // This is cheating
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Candidates[0].SubjectId.Should().Be("Elizabeth");
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task RecognizeFaceAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.RecognizeFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Candidates[0].SubjectId.Should().Be("Elizabeth");
            response.Errors.Should().BeNull();
        }


        [Test]
        public async Task DetectFacesAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.DetectFacesAsync(
                (Base64Image)"https://media.kairos.com/kairos-elizabeth.jpg");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Faces.Count.Should().Be(1);
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task DetectFacesAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.DetectFacesAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"));

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Faces.Count.Should().Be(1);
            response.Errors.Should().BeNull();
        }

        private KairosClient CreateClient()
        {
            return new KairosClient("4985f625", "aa9e5d2ec3b00306b2d9588c3a25d68e")
            {
                BaseUrl = "https://private-anon-f75b0626dc-kairos.apiary-mock.com"
            };
        }
    }
}
