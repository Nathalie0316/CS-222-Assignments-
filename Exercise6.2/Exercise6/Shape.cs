/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 

// First "Parent" Class
public abstract class Shape
{
    // Property to store height 
    public double Height { get; set; }
     // Property to store width
    public double Width { get; set; }

    // Abstract property for area (each subclass needs to provide their own implementation for it to work)
    public abstract double Area { get; }
}
