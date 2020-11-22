using System;
using System.IO;
using System.Threading.Tasks;
using FizzBuzzTest.Api.Controllers;
using FizzBuzzTest.Domain.Model;
using FizzBuzzTest.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace FizzBuzzTest.Api.Test.Controllers
{
	public class FizzBuzzControllerTest
	{
		[Test]
		public async Task GivenStartNumber_WhenGetFizzBuzz_ThenReturnExpectedResult()
		{
			// Arrange
			var configuration = GetConfig();
			var fizzBuzzService = new FizzBuzzService(new NullLogger<FizzBuzzService>());
			var sut = new FizzBuzzController(configuration, new NullLogger<FizzBuzzController>(), fizzBuzzService);
			var startNumber = 1;

			// Act
			var fizzBuzzResult = await sut.GetFizzBuzz(startNumber);

			// Assert
			var okObjectResult = (OkObjectResult)fizzBuzzResult.Result;
			Assert.AreEqual(30, ((FizzBuzzEntity)okObjectResult.Value).FizzBuzzResults.Count);
		}

		[Test]
		public async Task GivenStartNumberGreaterThanLimitNumber_WhenGetFizzBuzz_ThenReturnBadRequest()
		{
			// Arrange
			var configuration = GetConfig();
			var fizzBuzzService = new FizzBuzzService(new NullLogger<FizzBuzzService>());
			var sut = new FizzBuzzController(configuration, new NullLogger<FizzBuzzController>(), fizzBuzzService);
			var startNumber = 30;

			// Act
			var fizzBuzzResult = await sut.GetFizzBuzz(startNumber);

			// Assert
			var badRequestObjectResult = (BadRequestObjectResult)fizzBuzzResult.Result;
			Assert.IsInstanceOf<BadRequestObjectResult>(badRequestObjectResult);
			Assert.AreEqual("The start number should not be greater than 30", badRequestObjectResult.Value);
		}

		private IConfiguration GetConfig()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true)
				.AddEnvironmentVariables();

			return builder.Build();
		}
	}
}