using Mindbox.Package.Shapes;

namespace Mindbox.Package;

public static class Calculator
{
    public static IEnumerable<double> Calc(IEnumerable<IShape> shapes) => shapes.Select(s => s.GetArea());
}