using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class EnrolmentImage : BaseImage
    {
        [JsonProperty("attributes")]
        public FaceAttributes Attributes { get; set; }
    }
}
