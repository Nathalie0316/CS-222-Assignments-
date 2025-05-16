using System;
using Exercise4Library;

class Ex4Program
{
    static void Main()
    {
        Console.Write("Please enter a number that is less than or equal to 1000: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num <= 1000)
        {
            string results = PrimeFactorization.PrimeFactors(num);
            Console.WriteLine($"The Prime Factors of {num} are: {results}.");
        }
        else
        {
            Console.WriteLine("Your input is not valid. Make sure to enter an integer less than or equal to 1000.");
        }
    }
}
