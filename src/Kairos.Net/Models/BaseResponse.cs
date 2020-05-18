using System;
using System.Collections.Generic;

namespace Kairos.Net.Models
{
    public class BaseResponse
    {
        public IList<Error> Errors { get; set; }
    }
}
