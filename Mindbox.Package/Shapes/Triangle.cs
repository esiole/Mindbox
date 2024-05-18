using Mindbox.Package.Validation;
using Mindbox.Package.Validation.Messages;

namespace Mindbox.Package.Shapes;

public class Triangle : IShape
{
    public readonly double FirstSide;
    public readonly double SecondSide;
    public readonly double ThirdSide;

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        ValidationHelpers.CheckNegativeNumber(firstSide, TriangleErrorMessage.NegativeSide, nameof(firstSide));
        ValidationHelpers.CheckNegativeNumber(secondSide, TriangleErrorMessage.NegativeSide, nameof(secondSide));
        ValidationHelpers.CheckNegativeNumber(thirdSide, TriangleErrorMessage.NegativeSide, nameof(thirdSide));
        ValidationHelpers.CheckSecondIsLessThanFirst(secondSide + thirdSide, firstSide, TriangleErrorMessage.TooBigSide, nameof(firstSide));
        ValidationHelpers.CheckSecondIsLessThanFirst(firstSide + thirdSide, secondSide, TriangleErrorMessage.TooBigSide, nameof(secondSide));
        ValidationHelpers.CheckSecondIsLessThanFirst(firstSide + secondSide, thirdSide, TriangleErrorMessage.TooBigSide, nameof(thirdSide));

        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
    }

    public double GetArea()
    {
        var semiperimeter = (FirstSide + SecondSide + ThirdSide) / 2;
        return Math.Sqrt(semiperimeter * (semiperimeter - FirstSide) * (semiperimeter - SecondSide) * (semiperimeter - ThirdSide));
    }

    public bool CheckIsRectangular(double epsilon = 1e-10)
    {
        var hypotenuse = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));
        var hypotenuseInPow2 = Math.Pow(hypotenuse, 2);
        var difference = hypotenuseInPow2 + hypotenuseInPow2 - (Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2) + Math.Pow(ThirdSide, 2));
        return Math.Abs(difference) < epsilon;
    }
}