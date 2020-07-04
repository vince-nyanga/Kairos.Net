using System;

namespace Kairos.Net.Models
{
    public class MinHeadScale
    {
        public double Value { get;}

        public MinHeadScale(double value)
        {
            if (!IsValidValue(value))
            {
                throw new ArgumentException(
                    "Invalid value: minHeadScale should be between 0.015 and 0.5",
                    nameof(value));
            }
            Value = value;
        }

        private bool IsValidValue(double value)
        {
            return value >= 0.015 && value <= 0.5;
        }

        public static explicit operator MinHeadScale(double value)
        {
            return new MinHeadScale(value);
        }

        public static explicit operator double(MinHeadScale minHeadScale)
        {
            return minHeadScale.Value;
        }
    }
}
