namespace Mindbox.Package.Validation;

internal static class ValidationHelpers
{
    internal static void CheckNegativeNumber(double number, string errorMessage, string paramName)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException(errorMessage, paramName);
    }

    internal static void CheckSecondIsLessThanFirst(double first, double second, string errorMessage, string paramName)
    {
        if (first <= second)
            throw new ArgumentOutOfRangeException(errorMessage, paramName);
    }
}