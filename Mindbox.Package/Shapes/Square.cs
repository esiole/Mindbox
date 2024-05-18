using Mindbox.Package.Validation;
using Mindbox.Package.Validation.Messages;

namespace Mindbox.Package.Shapes;

public class Square : IShape
{
    public readonly double Side;

    public Square(double side)
    {
        ValidationHelpers.CheckNegativeNumber(side, SquareErrorMessage.NegativeSide, nameof(side));

        Side = side;
    }

    public double GetArea() => Math.Pow(Side, 2);
}