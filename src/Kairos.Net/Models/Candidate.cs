using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class Candidate
    {
        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        [JsonProperty("confidence")]
        public float Confidence { get; set; }

        [JsonProperty("enrollment_timestamp")]
        public long EnrollmentTimestamp { get; set; }
    }
}
