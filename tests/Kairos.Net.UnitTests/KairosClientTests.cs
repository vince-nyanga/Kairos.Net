﻿using System;
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

            Func<Task> func = async () => await client.EnrollImageAsync(null, "subject","gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("base64Image");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_WithNullOrEmptySubjectId_ThrowsException(string subjectId)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Base64Image)"base64", subjectId, "gallery");

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("subjectId");
        }

        [TestCase(null)]
        [TestCase("")]
        public void EnrollImageAsync_WithNullOrEmptyGalleryName_ThrowsException(string galleryName)
        {
            var client = CreateClient();

            Func<Task> func = async () => await client.EnrollImageAsync((Base64Image)"base64", "subject", galleryName);

            func.Should().Throw<ArgumentException>()
                .And.ParamName.Should().Be("galleryName");
        }

        private KairosClient CreateClient()
        {
            return new KairosClient("fakeAppId", "fakeApiKey");
        }
    }
}
