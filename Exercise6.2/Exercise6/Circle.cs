/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 3 (Exercise 6.2)
May 27th, 2025
*/ 

using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Height = radius * 2;
        Width = radius * 2;
    }

    public override double Area => Math.PI * Math.Pow(Height / 2, 2);
}
