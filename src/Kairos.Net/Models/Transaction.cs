using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class Transaction
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("topLeftX")]
        public int TopLeftX { get; set; }

        [JsonProperty("topLeftY")]
        public int TopLeftY { get; set; }

        [JsonProperty("gallery_name")]
        public string GallaryName { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("quality")]
        public float Quality { get; set; }

        [JsonProperty("confidence")]
        public float Confidence { get; set; }

        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("image_id")]
        public int ImageId { get; set; }

        [JsonProperty("eyeDistance")]
        public int EyeDistance { get; set; }

        [JsonProperty("roll")]
        public int Roll { get; set; }

        [JsonProperty("pitch")]
        public int Pitch { get; set; }

        [JsonProperty("yaw")]
        public int Yaw { get; set; }
    }
}
