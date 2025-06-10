using static System.Console;
using Exercise02.Models;
using System.Linq;

Clear();

using (var db = new Northwind())
{
    var cities = db.Customers
        .Select(c => c.City)
        .Distinct()
        .OrderBy(c => c)
        .ToList();

    WriteLine("Available cities:");
    WriteLine(string.Join(", ", cities));
    WriteLine();

    Write("Enter the name of a city: ");
    string city = ReadLine();

    var customersInCity = db.Customers
        .Where(c => c.City == city)
        .OrderBy(c => c.CompanyName)
        .ToList();

    WriteLine($"\nThere are {customersInCity.Count} customers in {city}:\n");

    foreach (var customer in customersInCity)
    {
        WriteLine(customer.CompanyName);
    }
}
