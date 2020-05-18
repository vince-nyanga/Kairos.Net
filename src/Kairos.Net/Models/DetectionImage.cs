using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
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
