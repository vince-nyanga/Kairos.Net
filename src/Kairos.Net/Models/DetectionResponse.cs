using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class DetectionResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<DetectionImage> Images { get; set; }
    }
}
