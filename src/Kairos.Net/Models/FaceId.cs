using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class FaceId
    {
        [JsonProperty("face_id")]
        public string Id { get; set; }

        [JsonProperty("enrollment_timestamp")]
        public string EnrollmentTimestamp { get; set; }
    }
}
