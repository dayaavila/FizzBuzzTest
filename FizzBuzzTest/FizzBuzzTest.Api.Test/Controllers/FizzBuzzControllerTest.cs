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

			// Act
			var fizzBuzzResult = await sut.GetFizzBuzz(1);

			// Assert
			Assert.IsInstanceOf<OkObjectResult>(fizzBuzzResult.Result);
			var okObjectResult = (OkObjectResult)fizzBuzzResult.Result;
			Assert.IsInstanceOf<FizzBuzzEntity>(okObjectResult.Value);
			Assert.AreEqual(30, ((FizzBuzzEntity)okObjectResult.Value).FizzBuzzResults.Count);
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