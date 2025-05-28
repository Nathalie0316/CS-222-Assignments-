/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 

using System;

// Program class for Console App 
class Program
{
    static void Main()
    {
        // Creating and printing the instances of each class as specified in the exercise instructions      
        var r = new Rectangle(3, 4.5);
        Console.WriteLine($"Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");

        var s = new Square(5);
        Console.WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");

        var c = new Circle(2.5);
        Console.WriteLine($"Circle H: {c.Height}, W: {c.Width}, Area: {c.Area}");
    }
}
