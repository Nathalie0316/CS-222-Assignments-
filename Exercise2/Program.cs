using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("{0,-10} {1,15} {2,30} {3,30}", "Type", "Byte(s) of memory", "Min", "Max");
        Console.WriteLine(new string('-', 90));

        DisplayInfo<sbyte>("sbyte");
        DisplayInfo<byte>("byte");
        DisplayInfo<short>("short");
        DisplayInfo<ushort>("ushort");
        DisplayInfo<int>("int");
        DisplayInfo<uint>("uint");
        DisplayInfo<long>("long");
        DisplayInfo<ulong>("ulong");
        DisplayInfo<float>("float");
        DisplayInfo<double>("double");
        DisplayInfo<decimal>("decimal");
    }

    static void DisplayInfo<T>(string typeName) where T : struct
    {
        var type = typeof(T);
        var size = System.Runtime.InteropServices.Marshal.SizeOf(type);
        var min = type.GetField("MinValue").GetValue(null);
        var max = type.GetField("MaxValue").GetValue(null);
        Console.WriteLine("{0,-10} {1,15} {2,30} {3,30}", typeName, size, min, max);
    }
}
