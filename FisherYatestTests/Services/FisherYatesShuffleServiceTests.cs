using FisherYates.Services;
using FisherYates.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FisherYatesTest.Services
{
    [TestClass]
    public class FisherYatesShuffleServiceTests
    {
        private Mock<IRandomNumberGenerator> _mockRandom;
        private IFisherYatesShuffleService _shuffleService;

        [TestInitialize]
        public void Setup()
        {
            _mockRandom = new Mock<IRandomNumberGenerator>();
            _shuffleService = new FisherYatesShuffleService(_mockRandom.Object);
        }

        #region Shuffle (Eager)
        [TestMethod]
        public void Shuffle_ShouldReturnExpectedOrder_WithControlledRandomness()
        {
            var input = new[] { "A", "B", "C" };

            _mockRandom.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                       .Returns(2)
                       .Returns(0);

            var result = _shuffleService.Shuffle(input).ToArray();

            CollectionAssert.AreEqual(new[] { "B", "A", "C" }, result);
        }

        [TestMethod]
        public void Shuffle_ShouldReturnSameElement_WhenSingleElement()
        {
            var input = new[] { "Z" };
            var result = _shuffleService.Shuffle(input).ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("Z", result[0]);
        }

        [TestMethod]
        public void Shuffle_ShouldReturnEmpty_WhenInputIsEmpty()
        {
            var input = Array.Empty<string>();
            var result = _shuffleService.Shuffle(input).ToArray();

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void Shuffle_ShouldNotModifyOriginalInput()
        {
            var input = new[] { "X", "Y", "Z" };
            var copy = input.ToArray();

            _mockRandom.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            _ = _shuffleService.Shuffle(input).ToArray();

            CollectionAssert.AreEqual(copy, input, "The input array should not be modified.");
        }

        [TestMethod]
        public void Shuffle_ShouldProduceDifferentResults_WithDifferentRandomness()
        {
            var input = new[] { "1", "2", "3" };

            var firstMock = new Mock<IRandomNumberGenerator>();
            firstMock.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                     .Returns(0).Returns(1);

            var secondMock = new Mock<IRandomNumberGenerator>();
            secondMock.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                      .Returns(1).Returns(0);

            var result1 = new FisherYatesShuffleService(firstMock.Object).Shuffle(input).ToArray();
            var result2 = new FisherYatesShuffleService(secondMock.Object).Shuffle(input).ToArray();

            CollectionAssert.AreNotEqual(result1, result2);
        }

        #endregion

        #region LazyShuffle

        [TestMethod]
        public void LazyShuffle_ShouldReturnExpectedOrder_WithControlledRandomness()
        {
            var input = new[] { "A", "B", "C" };

            _mockRandom.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                       .Returns(2)
                       .Returns(0);

            var result = _shuffleService.LazyShuffle(input).ToArray();

            CollectionAssert.AreEqual(new[] { "B", "A", "C" }, result);
        }

        [TestMethod]
        public void LazyShuffle_ShouldReturnSameElement_WhenSingleElement()
        {
            var input = new[] { "A" };
            var result = _shuffleService.LazyShuffle(input).ToArray();

            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("A", result[0]);
        }

        [TestMethod]
        public void LazyShuffle_ShouldReturnEmpty_WhenInputIsEmpty()
        {
            var input = Array.Empty<string>();
            var result = _shuffleService.LazyShuffle(input).ToArray();

            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void LazyShuffle_ShouldNotModifyOriginalInput()
        {
            var input = new[] { "A", "S", "D" };
            var copy = input.ToArray();

            _mockRandom.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            _ = _shuffleService.LazyShuffle(input).ToArray(); // Forcing enumeration

            CollectionAssert.AreEqual(copy, input);
        }

        [TestMethod]
        public void LazyShuffle_ShouldSupportPartialEnumeration()
        {
            var input = new[] { "1", "2", "3", "4", "5" };

            _mockRandom.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                       .Returns(4).Returns(3).Returns(2).Returns(1);

            var partial = _shuffleService.LazyShuffle(input).Take(2).ToArray();

            Assert.AreEqual(2, partial.Length);
            Assert.IsTrue(partial.All(x => input.Contains(x)));
        }

        #endregion
    }
}