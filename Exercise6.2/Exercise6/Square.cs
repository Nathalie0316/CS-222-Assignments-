/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 29th, 2025
*/ 

// "Child" class Square that is extended from the Shape Class
public class Square : Shape
{

    // Constructor that takes the size of the Square as a parameter
    public Square(double size)
    {
        Height = size; // Setting the height
        Width = size; // Setting width
    }

    // Overridding the abstract Area property from the Shape class (this one uses the formula for the area of a square)
    public override double Area => Width * Height;
}
