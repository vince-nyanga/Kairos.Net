using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class FaceAttributes
    {
        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("asian")]
        public float Asian { get; set; }

        [JsonProperty("black")]
        public float Black { get; set; }

        [JsonProperty("hispanic")]
        public float Hispanic { get; set; }

        [JsonProperty("white")]
        public float White { get; set; }

        [JsonProperty("other")]
        public float Other { get; set; }

        [JsonProperty("glasses")]
        public string Glasses { get; set; }

        [JsonProperty("lips")]
        public string Lips { get; set; }
    }
}