using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class ViewSubjectResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("face_ids")]
        public IList<FaceId> FaceIds { get; set; }
    }   
}