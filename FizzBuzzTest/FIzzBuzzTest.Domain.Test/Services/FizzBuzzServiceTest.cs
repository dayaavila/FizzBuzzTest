using System.Threading.Tasks;
using FizzBuzzTest.Domain.Services;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FizzBuzzTest.Domain.Test.Services
{
	public class FizzBuzzServiceTest
	{
		[Test]
		public async Task GivenStartNumber1AndLimitNumber10_WhenGetFizzBuzzResult_ReturnExpectedResults()
		{
			// Arrange
			var fizzBuzzService = new FizzBuzzService(new NullLogger<FizzBuzzService>());

			// Act
			var sut = await fizzBuzzService.GetFizzBuzzResult(1, 15);

			// Assert
			Assert.AreEqual(15, sut.FizzBuzzResults.Count);
			Assert.AreEqual("1", sut.FizzBuzzResults[0]);
			Assert.AreEqual("2", sut.FizzBuzzResults[1]);
			Assert.AreEqual("Fizz", sut.FizzBuzzResults[2]);
			Assert.AreEqual("4", sut.FizzBuzzResults[3]);
			Assert.AreEqual("Buzz", sut.FizzBuzzResults[4]);
			Assert.AreEqual("Fizz", sut.FizzBuzzResults[5]);
			Assert.AreEqual("7", sut.FizzBuzzResults[6]);
			Assert.AreEqual("8", sut.FizzBuzzResults[7]);
			Assert.AreEqual("Fizz", sut.FizzBuzzResults[8]);
			Assert.AreEqual("Buzz", sut.FizzBuzzResults[9]);
			Assert.AreEqual("11", sut.FizzBuzzResults[10]);
			Assert.AreEqual("Fizz", sut.FizzBuzzResults[11]);
			Assert.AreEqual("13", sut.FizzBuzzResults[12]);
			Assert.AreEqual("14", sut.FizzBuzzResults[13]);
			Assert.AreEqual("FizzBuzz", sut.FizzBuzzResults[14]);
		}

		[Test]
		public async Task GivenStartNumberGreaterThanLimitNumber_WhenGetFizzBuzzResult_ReturnThrowException()
		{
			// Arrange
			var fizzBuzzService = new FizzBuzzService(new NullLogger<FizzBuzzService>());

			// Act
			var sut = await fizzBuzzService.GetFizzBuzzResult(20, 15);

			// Assert
			Assert.AreEqual(0, sut.FizzBuzzResults.Count);
		}
	}
}