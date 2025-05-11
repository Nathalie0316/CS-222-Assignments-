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
        Console.WriteLine(new string('-', 100));
        Console.WriteLine("{0,-12} {1,15} {2,30} {3,30}", "Type", "Byte(s) of memory", "Min", "Max");
        Console.WriteLine(new string('-', 100));

        DisplayInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
        DisplayInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
        DisplayInfo("short", sizeof(short), short.MinValue, short.MaxValue);
        DisplayInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
        DisplayInfo("int", sizeof(int), int.MinValue, int.MaxValue);
        DisplayInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
        DisplayInfo("long", sizeof(long), long.MinValue, long.MaxValue);
        DisplayInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
        DisplayInfo("float", sizeof(float), float.MinValue, float.MaxValue);
        DisplayInfo("double", sizeof(double), double.MinValue, double.MaxValue);
        DisplayInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
    }

    static void DisplayInfo(string typeName, int size, object min, object max)
    {
        Console.WriteLine("{0,-10} {1,15} {2,30} {3,30}", typeName, size, min, max);
    }
}