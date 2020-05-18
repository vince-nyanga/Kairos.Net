using System;
namespace Kairos.Net.Models
{
    public class Base64Image
    {
        public Base64Image(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
            {
                throw new ArgumentException("base64String is required", nameof(base64String));
            }
            Value = base64String;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static implicit operator string(Base64Image base64Image)
        {
            return base64Image.ToString();
        }

        public static explicit operator Base64Image(string base64String)
        {
            return new Base64Image(base64String);
        }
    }
}
