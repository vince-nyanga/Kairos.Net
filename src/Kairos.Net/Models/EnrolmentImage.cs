using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class EnrolmentImage : BaseImage
    {
        [JsonProperty("attributes")]
        public FaceAttributes Attributes { get; set; }
    }
}
