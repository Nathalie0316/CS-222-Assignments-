/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 
public class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override double Area => Height * Width;
}
