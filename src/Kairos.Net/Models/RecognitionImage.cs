using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class RecognitionImage : BaseImage
    {
        [JsonProperty("candidates")]
        public IList<Candidate> Candidates { get; set; }
    }
}
