namespace FisherYates.Services.Interfaces;

/// <summary>
/// Service for shuffling collection of strings using the Fisher-Yates algorithm.
/// </summary>
public interface IFisherYatesShuffleService
{
    /// <summary>
    /// Shuffles the provided sequence of string elements.
    /// </summary>
    /// <param name="elements">collection of string elements to shuffle.</param>
    /// <returns>A new collection of strings.</returns>
    IEnumerable<string> Shuffle(IEnumerable<string> elements);


    /// <summary>
    /// Lazily performs a Fisher-Yates shuffle on the specified sequence of strings,
    /// yielding each shuffled element one by one. Useful for large datasets or partial consumption.
    /// </summary>
    /// <param name="elements">The collection of string elements to shuffle.</param>
    /// <returns>A lazily-evaluated sequence of shuffled strings.</returns>
    public IEnumerable<string> LazyShuffle(IEnumerable<string> elements);
}