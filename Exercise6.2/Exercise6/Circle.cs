/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 29th, 2025
*/ 

using System;

// "Child' class Circle that is extended from the Shape Class
public class Circle : Shape
{
    // Constructor that takes the radius of the circle as a parameter
    public Circle(double radius)
    {
        Height = radius * 2; // Diameter as height
        Width = radius * 2; // Diameter as width
    }

    // Overridding the abstract Area property from the Shape class (this one uses the formula for the area of a circle)
    public override double Area => Math.PI * (Height / 2) * (Height / 2);
}
