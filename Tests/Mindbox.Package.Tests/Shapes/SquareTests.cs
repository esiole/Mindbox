using Mindbox.Package.Shapes;

namespace Mindbox.Package.Tests.Shapes;

public class SquareTests
{
    [Fact]
    public void Should_throw_exception_on_negative_side()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Square(-1));
    }

    [Fact]
    public void Should_throw_exception_on_zero_side()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Square(0));
    }

    [Theory]
    [MemberData(nameof(SideData))]
    public void Should_keep_side(double side)
    {
        var square = new Square(side);
        Assert.Equal(side, square.Side);
    }

    [Theory]
    [MemberData(nameof(SideData))]
    public void Should_calc_area(double side)
    {
        var square = new Square(side);
        Assert.Equal(side * side, square.GetArea());
    }

    public static IEnumerable<object[]> SideData()
    {
        yield return [0.5];
        yield return [10];
        yield return [20.09];
    }
}