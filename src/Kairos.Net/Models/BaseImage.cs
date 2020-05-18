using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class BaseImage
    {
        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }
}
