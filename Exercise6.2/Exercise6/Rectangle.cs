/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 

// "Child' class Rectangle that is extended from the Shape Class
public class Rectangle : Shape
{
    // Constructor that takes the height and width of the rectangle as parameters
    public Rectangle(double height, double width)
    {
        Height = height; // Setting height
        Width = width; // Setting width
    }

    // Overridding the abstract Area property from the Shape class (this one uses the formula for the area of a rectangle)
    public override double Area => Height * Width;
}
