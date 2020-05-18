using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class DetectionResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<DetectionImage> Images { get; set; }
    }
}
