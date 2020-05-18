using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class VerifyFaceResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<BaseImage> Images { get; set; }
    }
}
