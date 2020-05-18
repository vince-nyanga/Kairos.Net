using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class BaseImage
    {
        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }
}
