using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class Face
    {
        [JsonProperty("topLeftX")]
        public int TopLeftX { get; set; }

        [JsonProperty("topLeftY")]
        public int TopLeftY { get; set; }

        [JsonProperty("chinTipX")]
        public int ChinTipX { get; set; }

        [JsonProperty("chinTipY")]
        public int ChinTipY { get; set; }

        [JsonProperty("rightEyeCenterX")]
        public int RightEyeCenterX { get; set; }

        [JsonProperty("rightEyeCenterY")]
        public int RightEyeCenterY { get; set; }

        [JsonProperty("leftEyeCenterX")]
        public int LeftEyeCenterX { get; set; }

        [JsonProperty("leftEyeCenterY")]
        public int LeftEyeCenterY { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("roll")]
        public int Roll { get; set; }

        [JsonProperty("pitch")]
        public int Pitch { get; set; }

        [JsonProperty("yaw")]
        public int Yaw { get; set; }

        [JsonProperty("quality")]
        public float Quality { get; set; }

        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("attributes")]
        public FaceAttributes Attributes { get; set; }
    }
}