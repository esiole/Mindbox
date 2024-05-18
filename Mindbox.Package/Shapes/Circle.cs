using Mindbox.Package.Validation;
using Mindbox.Package.Validation.Messages;

namespace Mindbox.Package.Shapes;

public class Circle : IShape
{
    public readonly double Radius;

    public Circle(double radius)
    {
        ValidationHelpers.CheckNegativeNumber(radius, CircleErrorMessage.NegativeRadius, nameof(radius));

        Radius = radius;
    }

    public double GetArea() => Math.PI * Math.Pow(Radius, 2);
}