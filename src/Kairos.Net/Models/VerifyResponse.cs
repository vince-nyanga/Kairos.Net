using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class VerifyResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<BaseImage> Images { get; set; }
    }
}
