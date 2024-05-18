using Mindbox.Package.Shapes;

namespace Mindbox.Package.Tests.Shapes;

public class CircleTests
{
    [Fact]
    public void Should_throw_exception_on_negative_radius()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Fact]
    public void Should_throw_exception_on_zero_radius()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
    }

    [Theory]
    [MemberData(nameof(RadiiData))]
    public void Should_keep_radius(double radius)
    {
        var circle = new Circle(radius);
        Assert.Equal(radius, circle.Radius);
    }

    [Theory]
    [MemberData(nameof(RadiiData))]
    public void Should_calc_area(double radius)
    {
        var circle = new Circle(radius);
        Assert.Equal(Math.PI * Math.Pow(radius, 2), circle.GetArea());
    }

    public static IEnumerable<object[]> RadiiData()
    {
        yield return [0.5];
        yield return [10];
        yield return [20.09];
    }
}