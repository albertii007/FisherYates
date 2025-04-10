# Skedda Technical Challenge – Task 2: Fisher-Yates

For this challenge, I picked **Task 2: Fisher-Yates**, which involved designing and testing a simple shuffle algorithm in .NET.

---

## What’s in the project

- A working **Fisher-Yates shuffle** algorithm inside a service.
- A GET API endpoint at `/fisheryates` that takes a dasherized string (like `A-B-C`) and returns the shuffled version.
- An `IRandomNumberGenerator` interface to separate the randomness from the algorithm.
- Full **dependency injection setup** in `Program.cs`.
- Two shuffle methods:
  - `Shuffle()` for eager evaluation.
  - `LazyShuffle()` that streams results using `yield return`.

---

## Testing

I wrote **over 10 unit tests** covering:

- Normal and edge cases (empty input, single items).
- Making sure the original input isn’t changed.
- Verifying that shuffling is deterministic by mocking random values.
- Testing lazy evaluation and partial results.
- Checking that null inputs throw exceptions.

All tests use **Moq** to control the random behavior and keep things predictable.

---

## A quick note on my approach

At first, I followed the instructions closely and didn’t implement the shuffle itself — since the doc said to leave methods unimplemented. I focused on building a solid structure with clean separation and test scaffolding.

After reading your feedback (thank you for that!) and going back over the instructions, I realized that showing how I’d handle randomness and make the code testable was important — even without a full algorithm implementation.

So I updated my solution:
- Added the actual shuffle.
- Mocked randomness through an interface.
- Rewrote the tests to be deterministic and reliable.

---

## Thanks again

This was a fun challenge and a great learning opportunity. I’d love to stay in touch and be considered for future roles if they come up.

Thanks again!  
**– Albert Kunushevci**
