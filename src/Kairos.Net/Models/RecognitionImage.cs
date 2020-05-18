using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class RecognitionImage : BaseImage
    {
        [JsonProperty("candidates")]
        public IList<Candidate> Candidates { get; set; }
    }
}
