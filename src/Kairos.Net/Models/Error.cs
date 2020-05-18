using System.Diagnostics.CodeAnalysis;

namespace Kairos.Net.Models
{
    [ExcludeFromCodeCoverage]
    public class Error
    {
        public string Message { get; set; }
        public int ErrCode { get; set; }
    }
}