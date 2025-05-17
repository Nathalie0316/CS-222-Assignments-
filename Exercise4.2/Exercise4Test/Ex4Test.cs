/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 2 (Exercise 4.2)
May 17th, 2025
*/ 

using Xunit;
using Exercise4Library;

namespace Ex4Test
{
    public class Exercise4Tests
    {
        // Tests different inputs against expected output 
        [Theory]
        [InlineData(4, "2 x 2")]
        [InlineData(6, "2 x 3")]
        [InlineData(10, "2 x 5")]
        [InlineData(20, "2 x 2 x 5")]
        [InlineData(30, "2 x 3 x 5")]
        [InlineData(1, "No prime factors available for this number.")]

        // Call the method with input and compare it to the expected string
        public void TestExercise4(int input, string expected)
        {
            string result = PrimeFactorization.PrimeFactors(input);
            Assert.Equal(expected, result); // Make sure that the expected and the actual results match
        }
    }
}
