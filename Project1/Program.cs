namespace HelloWorld;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        car car = new car("white");
        car.SetColor("blue");

        int rectangleArea = Rectangle.Calculate(8, 9);
        Console.WriteLine(rectangleArea);
    }
}
//
class car
{
    private string color;
    public car(string color)
    {
        this.color = color;
    }
    public void SetColor(string color)
    {
        this.color = color;
    }
}


// Method that calculates area of rectangle without an instance of class Rectangle
class Rectangle
{
    public static int Calculate(int a, int b)
    {
        return a * b;
    }
}