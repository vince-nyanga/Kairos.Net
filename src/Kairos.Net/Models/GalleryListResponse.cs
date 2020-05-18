using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class GalleryListResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("gallery_ids")]
        public IList<string> GalleryNames { get; set; }
    }
}
