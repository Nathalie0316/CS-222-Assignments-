/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 2 (Exercise 4.2)
May 17th, 2025
*/ 

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exercise4Library
{
    public static class PrimeFactorization
    {
        // Method "PrimeFactors" to return the prime factors of a user input number as a string
        public static string PrimeFactors(int num)
        {
            // If the inputted number is less then 2, automatically say that there are no prime factors for the number
            if (num < 2)
                return "No prime factors available for this number.";

            // Create new list to store the prime factors 
            List<int> factors = new List<int>();
            int divisor = 2; // Start dividing from 2 (Smallest prime)

            // Loop until the inputted number becomes 1
            while (num > 1)
            {
                // Check if the number is divisible by the current divisor number (no remainder left)
                while (num % divisor == 0)
                {
                    // If yes, add divisor to the factors list and divide the number by it
                    factors.Add(divisor);
                    num /= divisor;
                }

                // Increment divisor by 1
                divisor++;
            }

            // Join the factors and return the resulting string
            return string.Join(" x ", factors);
        }
    }
}