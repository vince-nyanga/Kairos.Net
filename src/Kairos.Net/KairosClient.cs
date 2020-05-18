using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kairos.Net.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Kairos.Net
{
    public class KairosClient
    {
        public string BaseUrl { get; set; } = "https://api.kairos.com";
        private const string CONTENT_TYPE = "application/json";

        private readonly string _appId;
        private readonly string _apiKey;

        public KairosClient(string appId, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("appId is required", nameof(appId));
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("apiKey is required", nameof(apiKey));
            }

            _appId = appId;
            _apiKey = apiKey;
        }

      
        public Task<EnrolmentResponse> EnrollImageAsync(Base64Image base64Image, string subjectId, string galleryName)
        {
            if (base64Image is null)
            {
                throw new ArgumentException("base64 image is required", nameof(base64Image));
            }

            if (string.IsNullOrWhiteSpace(subjectId))
            {
                throw new ArgumentException("subject id is required", nameof(subjectId));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            return SendImage<EnrolmentResponse>("enroll", base64Image.Value, subjectId, galleryName);
        }

        public Task<EnrolmentResponse> EnrollImageAsync(Uri imageUri, string subjectId, string galleryName)
        {
            if (imageUri is null)
            {
                throw new ArgumentException("image uri is required",nameof(imageUri));
            }

            if (string.IsNullOrWhiteSpace(subjectId))
            {
                throw new ArgumentException("subject id is required", nameof(subjectId));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            return SendImage<EnrolmentResponse>("enroll",imageUri.ToString(), subjectId, galleryName); 
        }


        public Task<VerifyResponse> VerifyImageAsync(Base64Image base64Image, string subjectId, string galleryName)
        {
            if (base64Image is null)
            {
                throw new ArgumentException("base64 image is required",nameof(base64Image));
            }

            if (string.IsNullOrWhiteSpace(subjectId))
            {
                throw new ArgumentException("subject id is required", nameof(subjectId));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name", nameof(galleryName));
            }

            return SendImage<VerifyResponse>("verify", base64Image.Value, subjectId, galleryName);
        }

        public Task<VerifyResponse> VerifyImageAsync(Uri imageUri, string subjectId, string galleryName)
        {
            if (imageUri is null)
            {
                throw new ArgumentException("base64 image is required", nameof(imageUri));
            }

            if (string.IsNullOrWhiteSpace(subjectId))
            {
                throw new ArgumentException("subject id is required", nameof(subjectId));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name", nameof(galleryName));
            }

            return SendImage<VerifyResponse>("verify",imageUri.ToString(), subjectId, galleryName);
        }

        private async Task<T> SendImage<T>(string resourceUri,string image, string subjectId, string galleryName)
        {
            var httpClient = new RestClient(BaseUrl);
            var request = CreateRequest(resourceUri, Method.POST);

            var payload = new
            {
                image = image,
                subject_id = subjectId,
                gallery_name = galleryName
            };

            request.AddJsonBody(payload);

            var response = await httpClient.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private async Task<T> SendImage<T>(string resourceUri, string image, string galleryName)
        {
            var httpClient = new RestClient(BaseUrl);
            var request = CreateRequest(resourceUri, Method.POST);

            var payload = new
            {
                image = image,
                gallery_name = galleryName
            };

            request.AddJsonBody(payload);

            var response = await httpClient.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(method)
            {
                Resource = resource
            };

            request.AddHeader("app_id", _appId);
            request.AddHeader("app_key", _apiKey);
            request.AddHeader("Content-Type", CONTENT_TYPE);

            return request;
        }

        public Task<RecognitionResponse> RecognizeImageAsync(Base64Image base64Image, string galleryName)
        {
            if (base64Image is null)
            {
                throw new ArgumentNullException(nameof(base64Image));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            return SendImage<RecognitionResponse>("recognize", base64Image.Value, galleryName);
        }

        public Task<RecognitionResponse> RecognizeImageAsync(Uri imageUri, string galleryName)
        {
            if (imageUri is null)
            {
                throw new ArgumentException("image uri is required",nameof(imageUri));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            return SendImage<RecognitionResponse>("recognize", imageUri.ToString(), galleryName);
        }
    }
}
