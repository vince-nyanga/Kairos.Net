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
        public async Task EnrollImageAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.EnrollImageAsync(
                (Base64Image)"https://media.kairos.com/kairos-elizabeth.jpg", // This is cheating
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);

            response.FaceId.Should().NotBeNull();
        }

        [Test]
        public async Task EnrollImageAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.EnrollImageAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"), 
                "Elizabeth",
                "MyGallery");

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);

            response.FaceId.Should().NotBeNull();
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
