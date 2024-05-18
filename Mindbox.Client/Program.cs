using Mindbox.Package.Shapes;

IShape[] shapes = [new Circle(5), new Square(5), new Triangle(5, 5, 5), new Triangle(5, 3, 4)];

foreach (var shape in shapes)
{
    var area = shape.GetArea();
    Console.WriteLine($"Calculate area for {shape.GetType().Name}: {Math.Round(area, 2)}");
}