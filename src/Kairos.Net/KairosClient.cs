using System;
using System.Threading.Tasks;
using Kairos.Net.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Kairos.Net
{
    public class KairosClient
    { 
        private const string CONTENT_TYPE = "application/json";

        private readonly string _appId;
        private readonly string _apiKey;
        private readonly IRestClient _restClient;

        public KairosClient(string appId, string apiKey, string baseUrl= "https://api.kairos.com")
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("appId is required", nameof(appId));
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("apiKey is required", nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("base url is requied", nameof(baseUrl));
            }

            _appId = appId;
            _apiKey = apiKey;
            _restClient = new RestClient(baseUrl);
        }

      
        public Task<EnrollFaceResponse> EnrollFaceAsync(Base64Image base64Image, string subjectId, string galleryName)
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

            var payload = new
            {
                image = base64Image.Value,
                subject_id = subjectId,
                gallery_name = galleryName
            };

            return SendPostRequest<EnrollFaceResponse>("enroll", payload);
        }

        public Task<EnrollFaceResponse> EnrollFaceAsync(Uri imageUri, string subjectId, string galleryName)
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

            var payload = new
            {
                image = imageUri.ToString(),
                subject_id = subjectId,
                gallery_name = galleryName
            };

            return SendPostRequest<EnrollFaceResponse>("enroll",payload); 
        }


        public Task<VerifyFaceResponse> VerifyFaceAsync(Base64Image base64Image, string subjectId, string galleryName)
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

            var payload = new
            {
                image = base64Image.Value,
                subject_id = subjectId,
                gallery_name = galleryName
            };
            return SendPostRequest<VerifyFaceResponse>("verify", payload);
        }

        public Task<VerifyFaceResponse> VerifyFaceAsync(Uri imageUri, string subjectId, string galleryName)
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

            var payload = new
            {
                image = imageUri.ToString(),
                subject_id = subjectId,
                gallery_name = galleryName
            };

            return SendPostRequest<VerifyFaceResponse>("verify",payload);
        }

        private async Task<T> SendPostRequest<T>(string resourceUri,object payload)
        {
            var request = CreateRequest(resourceUri, Method.POST);

            if (payload != null)
            {
                request.AddJsonBody(payload);
            }
            
            var response = await _restClient.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public Task<GalleryListResponse> ListGalleriesAsync()
        {
            return SendPostRequest<GalleryListResponse>("gallery/list_all", null);
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

        public Task<RecognizeFaceResponse> RecognizeFaceAsync(Base64Image base64Image, string galleryName)
        {
            if (base64Image is null)
            {
                throw new ArgumentNullException(nameof(base64Image));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            var payload = new
            {
                image = base64Image.Value,
                gallery_name = galleryName
            };

            return SendPostRequest<RecognizeFaceResponse>("recognize", payload);
        }

        public Task<RecognizeFaceResponse> RecognizeFaceAsync(Uri imageUri, string galleryName)
        {
            if (imageUri is null)
            {
                throw new ArgumentException("image uri is required",nameof(imageUri));
            }

            if (string.IsNullOrWhiteSpace(galleryName))
            {
                throw new ArgumentException("gallery name is required", nameof(galleryName));
            }

            var payload = new
            {
                image = imageUri.ToString(),
                gallery_name = galleryName
            };

            return SendPostRequest<RecognizeFaceResponse>("recognize",payload);
        }

        public Task<DetectFacesResponse> DetectFacesAsync(Base64Image base64Image, string selector = "ROLL")
        {
            if (base64Image is null)
            {
                throw new ArgumentException("base64 image is required",nameof(base64Image));
            }

            var payload = new
            {
                image = base64Image.Value,
                selector = selector
            };

            return SendPostRequest<DetectFacesResponse>("detect", payload);
        }

        public Task<DetectFacesResponse> DetectFacesAsync(Uri imageUri, string selector = "ROLL")
        {
            if (imageUri is null)
            {
                throw new ArgumentException("image uri is required",nameof(imageUri));
            }

            var payload = new
            {
                image = imageUri.ToString(),
                selector = selector
            };

            return SendPostRequest<DetectFacesResponse>("detect", payload);
        }
    }
}
