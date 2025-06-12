/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 5 (Exercise 12.2)
June 12th, 2025
*/

using Microsoft.EntityFrameworkCore;

namespace Exercise02.Models;

// Manages the database connection and provides access to tables 
public class Northwind : DbContext
{
    // Represents the Customers table in the database
    public DbSet<Customer> Customers { get; set; }

    // Setting the connection string to the database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Building path to the Northwind.db file and using the path
        string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        optionsBuilder.UseSqlite($"Filename={path}");
    }
}
