using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kairos.Net.Interfaces;
using Kairos.Net.Models;
using NUnit.Framework;

namespace Kairos.Net.IntegrationTests
{
    [TestFixture]
    public class KairosClientTests
    {
        private readonly string _subjectId = "Elizabeth";
        private readonly string _galleryName = "MyGallery";

        [Test]
        public async Task EnrollFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.EnrollFaceAsync(
                (Base64Image)TestUtils.TestImage,
                _subjectId,
                _galleryName);

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
                _subjectId,
                _galleryName);

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.FaceId.Should().NotBeNull();
        }

        [Test]
        public async Task VerifyFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.VerifyFaceAsync(
                (Base64Image)TestUtils.TestImage,
                _subjectId,
                _galleryName);

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
                _subjectId,
                _galleryName);

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task RecognizeFaceAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.RecognizeFaceAsync(
                (Base64Image)TestUtils.TestImage,
                _galleryName);

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Candidates[0].SubjectId.Should().Be(_subjectId);
            response.Errors.Should().BeNull();
        }

        [Test]
        public async Task RecognizeFaceAsync_WithImageUri_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.RecognizeFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                _galleryName);

            response.Should().NotBeNull();
            response.Images.Count.Should().Be(1);
            response.Images[0].Candidates[0].SubjectId.Should().Be(_subjectId);
            response.Errors.Should().BeNull();
        }


        [Test]
        public async Task DetectFacesAsync_WithBase64Image_ReturnsCorrectResponse()
        {
            var client = CreateClient();


            var response = await client.DetectFacesAsync((Base64Image)TestUtils.TestImage);

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

        [Test]
        public async Task ListGalleriesAsync_ReturnsGalleryList()
        {
            
            var client = CreateClient();
            await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                _subjectId,
                _galleryName
                );

            var response = await client.ListGalleriesAsync();

            response.GalleryNames.Should().Contain(_galleryName);

        }

        [Test]
        public async Task ListFacesAsync_ReturnsFaceList()
        { 
            var client = CreateClient();
            await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                _subjectId,
                _galleryName
                );

            var response = await client.ListFacesAsync(_galleryName);

            response.Faces.Should().Contain(_subjectId);
        }

        [Test]
        public async Task RemoveGalleryAsync_RemovesGallery()
        {
            var client = CreateClient();
            await client.EnrollFaceAsync(
                new Uri("https://media.kairos.com/kairos-elizabeth.jpg"),
                _subjectId,
                _galleryName
                );

            var response = await client.RemoveGalleryAsync(_galleryName);

            response.Errors.Should().BeNullOrEmpty();
        }

        private IKairosClient CreateClient()
        {
            return new KairosClient(
                appId: "4985f625",
                appKey: "aa9e5d2ec3b00306b2d9588c3a25d68e",
                baseUrl: "https://private-anon-f75b0626dc-kairos.apiary-mock.com");
            
        }
    }
}
