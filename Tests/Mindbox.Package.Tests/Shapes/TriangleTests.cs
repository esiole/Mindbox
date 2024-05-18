using Mindbox.Package.Shapes;

namespace Mindbox.Package.Tests.Shapes;

public class TriangleTests
{
    [Fact]
    public void Should_throw_exception_on_negative_side()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, -1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, -1));
    }

    [Fact]
    public void Should_throw_exception_on_zero_side()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 0, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, 0));
    }

    [Fact]
    public void Should_throw_exception_on_too_big_side()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(10, 1, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 10, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 1, 10));
    }

    [Theory]
    [MemberData(nameof(SideData))]
    public void Should_keep_sides(double firstSide, double secondSide, double thirdSide, double _)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        Assert.Equal(firstSide, triangle.FirstSide);
        Assert.Equal(secondSide, triangle.SecondSide);
        Assert.Equal(thirdSide, triangle.ThirdSide);
    }

    [Theory]
    [MemberData(nameof(SideData))]
    public void Should_calc_area(double firstSide, double secondSide, double thirdSide, double expectedArea)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        Assert.Equal(expectedArea, triangle.GetArea());
    }

    [Theory]
    [MemberData(nameof(CheckRectangularData))]
    public void Should_check_rectangular(double firstSide, double secondSide, double thirdSide, bool isRectangular)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        Assert.Equal(isRectangular, triangle.CheckIsRectangular());
    }

    [Theory]
    [InlineData(1e-8, true)]
    [InlineData(1e-9, false)]
    public void Should_check_rectangular_given_the_epsilon(double epsilon, bool isRectangular)
    {
        var triangle = new Triangle(0.25, 0.8, Math.Sqrt(Math.Pow(0.25, 2) + Math.Pow(0.8 + 1 * 1e-9, 2)));
        Assert.Equal(isRectangular, triangle.CheckIsRectangular(epsilon));
    }

    public static IEnumerable<object[]> SideData()
    {
        yield return [0.5, 0.5, 0.5, Math.Pow(0.5, 2) * Math.Sqrt(3) / 4];
        yield return [3, 5, 4, 6];
        yield return [10, 8, 5, Math.Sqrt(6279) / 4];
    }

    public static IEnumerable<object[]> CheckRectangularData()
    {
        yield return [0.5, 0.5, 0.5, false];
        yield return [3, 5, 4, true];
        yield return [0.25, 0.8, Math.Sqrt(Math.Pow(0.25, 2) + Math.Pow(0.8, 2)), true];
        yield return [10, 8, 5, false];
        yield return [10.25, 18, Math.Sqrt(Math.Pow(18, 2) - Math.Pow(10.25, 2)), true];
    }
}