/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 5 (Exercise 12.2)
June 12th, 2025
*/

using System.ComponentModel.DataAnnotations;

namespace Exercise02.Models;

// Represents a Customer from the Northwind database
public class Customer
{
    [Key] // Marking this property as the primary key
    public string CustomerID { get; set; }

    // Name of company 
    public string CompanyName { get; set; }

    // City of customer 
    public string City { get; set; }
}
