using FisherYates.Services.Interfaces;

namespace FisherYates.Services;

/// <summary>
/// Provides an abstraction for generating random numbers.
/// </summary>
public class RandomNumberGenerator : IRandomNumberGenerator
{
    // Uses ThreadLocal to maintain thread safety and statelessness in a Singleton context, minimizing allocations.
    private static readonly ThreadLocal<Random> LocalRandom = new(() => new Random());

    /// <inheritdoc/>
    public int Next(int minValue, int maxValue) => LocalRandom.Value!.Next(minValue, maxValue);
}