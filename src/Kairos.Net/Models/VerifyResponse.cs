using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class VerifyResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<BaseImage> Images { get; set; }
    }
}
