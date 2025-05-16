using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercise4Library
{
    public static class PrimeFactorization
    {
        public static string PrimeFactors(int num)
        {
            if (num < 2)
                return "No prime factors available for this number.";

            List<int> factors = new List<int>();
            int divisor = 2;

            while (num > 1)
            {
                while (num % divisor == 0)
                {
                    factors.Add(divisor);
                    num /= divisor;
                }
                divisor++;
            }
            return string.Join(" x ", factors);
        }
    }
}