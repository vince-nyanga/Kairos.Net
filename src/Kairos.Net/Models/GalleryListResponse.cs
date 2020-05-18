using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class GalleryListResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("gallery_ids")]
        public IList<string> GalleryNames { get; set; }
    }
}
