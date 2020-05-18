using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class BaseResponse
    {
        public IList<Error> Errors { get; set; }
    }
}
