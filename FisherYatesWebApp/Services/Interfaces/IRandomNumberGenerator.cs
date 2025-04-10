namespace FisherYates.Services.Interfaces;

/// <summary>
/// Provides an abstraction for generating random numbers.
/// </summary>
public interface IRandomNumberGenerator
{
    /// <summary>
    /// Returns a non-negative random integer that is within a specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
    /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue.</returns>
    int Next(int minValue, int maxValue);
}