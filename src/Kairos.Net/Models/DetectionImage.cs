using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class DetectionImage
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("faces")]
        public IList<Face> Faces { get; set; }
    }
}
