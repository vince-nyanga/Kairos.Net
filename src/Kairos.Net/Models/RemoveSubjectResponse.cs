﻿using Newtonsoft.Json;

namespace Kairos.Net.Models
{
    public class RemoveSubjectResponse : BaseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
