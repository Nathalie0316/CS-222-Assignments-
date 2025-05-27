/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 
public class Square : Shape
{
    public Square(double size)
    {
        Height = size;
        Width = size;
    }

    public override double Area => Height * Width;
}
