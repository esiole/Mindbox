namespace Mindbox.Package.Validation.Messages;

internal static class TriangleErrorMessage
{
    internal const string NegativeSide = "A side of a triangle cannot be less than or equal to 0";
    internal const string TooBigSide = "A side of a triangle must be less than the sum of the other two sides";
}