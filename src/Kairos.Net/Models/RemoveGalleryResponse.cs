using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class RemoveGalleryResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
