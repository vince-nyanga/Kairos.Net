using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class RecognitionResponse : BaseResponse
    {
        [JsonProperty("images")]
        public IList<RecognitionImage> Images { get; set; }
    }
}
