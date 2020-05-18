using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class EnrolmentResponse : BaseResponse
    {
        [JsonProperty("face_id")]
        public string FaceId { get; set; }

        [JsonProperty("images")]
        public IList<EnrolmentImage> Images { get; set; }
    }
}
