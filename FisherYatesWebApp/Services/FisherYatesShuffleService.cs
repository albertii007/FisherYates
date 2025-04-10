using FisherYates.Services.Interfaces;

namespace FisherYates.Services;

/// <summary>
/// Service that implements the Fisher-Yates algorithm to shuffle a collection of strings.
/// </summary>
public class FisherYatesShuffleService : IFisherYatesShuffleService
{
    private readonly IRandomNumberGenerator _random;

    public FisherYatesShuffleService(IRandomNumberGenerator randomNumberGenerator)
    {
        _random = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
    }

    /// <inheritdoc/>
    public IEnumerable<string> Shuffle(IEnumerable<string> elements)
    {
        if (elements == null)
            throw new ArgumentNullException(nameof(elements));

        var array = elements.ToArray();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = _random.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }

        return array;
    }

    /// <inheritdoc/>
    public IEnumerable<string> LazyShuffle(IEnumerable<string> elements)
    {
        if (elements == null)
            throw new ArgumentNullException(nameof(elements));

        var array = elements.ToArray();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = _random.Next(0, i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }

        // Stream result one-by-one
        for (int i = 0; i < array.Length; i++)
        {
            yield return array[i];
        }
    }
}