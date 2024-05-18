using Mindbox.Package.Shapes;

namespace Mindbox.Package.Tests;

public class CalculatorTests
{
    [Fact]
    public void Should_calc_area_without_knowing_type()
    {
        IShape[] shapes = [new Circle(5), new Square(5), new Triangle(5, 5, 5), new Triangle(5, 3, 4)];
        double[] expectedAreas = [Math.PI * Math.Pow(5, 2), Math.Pow(5, 2), Math.Pow(5, 2) * Math.Sqrt(3) / 4, 6];
        var areas = Calculator.Calc(shapes);
        Assert.Equal(expectedAreas, areas);
    }
}