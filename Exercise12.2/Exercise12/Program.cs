/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 5 (Exercise 12.2)
June 12th, 2025
*/

using static System.Console;
using Exercise02.Models;
using System.Linq;

Clear(); // Clearing the terminal 

// Using the Northwind database
using (var db = new Northwind())
{
    // Getting an alphabetically ordered list of all unique customer cities 
    var cities = db.Customers
        .Select(c => c.City)
        .Distinct()
        .OrderBy(c => c)
        .ToList();

     // Displaying all the available cities
    WriteLine("Available cities:");
    WriteLine(string.Join(", ", cities));
    WriteLine();

    // Prompting the user to enter a city
    Write("Enter the name of a city: ");
    string city = ReadLine();

    // Query for all customers in the inputted city
    var customersInCity = db.Customers
        .Where(c => c.City == city)
        .OrderBy(c => c.CompanyName)
        .ToList();

    // Displaying how many customers in the inputted city
    WriteLine($"\nThere are {customersInCity.Count} customers in {city}:\n");

    // Displaying each company name
    foreach (var customer in customersInCity)
    {
        WriteLine(customer.CompanyName);
    }
}
