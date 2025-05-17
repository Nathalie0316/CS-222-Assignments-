/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 2 (Exercise 4.2)
May 17th, 2025
*/ 

using System;
using Exercise4Library; // Importing the created library

class Ex4Program
{
    static void Main()
    {
        // User prompt for input
        Console.Write("Please enter a number that is less than or equal to 1000: ");
        // Try to parse input and check that it's <= 1000
        if (int.TryParse(Console.ReadLine(), out int num) && num <= 1000)
        {
            // Call the PrimeFactors method 
            string results = PrimeFactorization.PrimeFactors(num);
            Console.WriteLine($"The Prime Factors of {num} are: {results}."); // Display method results
        }
        else
        {
            // Handling invalid input
            Console.WriteLine("Your input is not valid. Make sure to enter an integer less than or equal to 1000.");
        }
    }
}
