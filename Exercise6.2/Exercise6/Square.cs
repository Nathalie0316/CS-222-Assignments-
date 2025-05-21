public class Square : Shape
{
    public Square(double size)
    {
        Height = size;
        Width = size;
    }

    public override double Area => Height * Width;
}
