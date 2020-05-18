using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class GalleryFacesResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subject_ids")]
        public IList<string> SubjectIds { get; set; }
    }
}
