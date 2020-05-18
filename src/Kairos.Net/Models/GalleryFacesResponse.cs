using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class GalleryFacesResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subject_ids")]
        public IList<string> SubjectIds { get; set; }
    }
}
