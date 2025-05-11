/*
Nathalie C. Lezama
CS 222 C# Programming
Assignment 1 (Exercise 2.2)
May 11th, 2025
*/ 

using System; 

class Exercise2Wk1
{
    static void Main()
    {
        Console.WriteLine(new string('-', 100)); // Printing the horizontal lines to get the same visual as in the example
        Console.WriteLine("{0,-12} {1,15} {2,30} {3,30}", "Type", "Byte(s) of memory", "Min", "Max"); // Aligning and spacing the "titles" of each category/column 
        Console.WriteLine(new string('-', 100)); // Printing the horizontal lines to get the same visual as in the example

        // Calling the "InformationDisp" Method on each of the data types
        InformationDisp("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        InformationDisp("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        InformationDisp("short", sizeof(short), short.MinValue, short.MaxValue);
        InformationDisp("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        InformationDisp("int", sizeof(int), int.MinValue, int.MaxValue);
        InformationDisp("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        InformationDisp("long", sizeof(long), long.MinValue, long.MaxValue);
        InformationDisp("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        InformationDisp("float", sizeof(float), float.MinValue, float.MaxValue);
        InformationDisp("double", sizeof(double), double.MinValue, double.MaxValue);
        InformationDisp("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
    }

    // "InformationDisp" Method to display data type information 
    static void InformationDisp(string typeName, int size, object min, object max)
    {
        // Formatting and printing the type name, size, min value, and max value
        Console.WriteLine("{0,-10} {1,15} {2,30} {3,30}", typeName, size, min, max);
    }
}