using System;
using System.Threading.Tasks;
using FizzBuzzTest.CrossCutting.Exceptions;
using FizzBuzzTest.Domain.Interfaces;
using FizzBuzzTest.Domain.Model;
using Microsoft.Extensions.Logging;

namespace FizzBuzzTest.Domain.Services
{
	public class FizzBuzzService : IFizzBuzzService
	{
		private readonly ILogger<FizzBuzzService> _logger;

		public FizzBuzzService(ILogger<FizzBuzzService> logger)
		{
			_logger = logger;
		}

		public async Task<FizzBuzzEntity> GetFizzBuzzResult(int startNumber, int limitNumber)
		{
			try
			{
				var fizzBuzzEntity = new Task<FizzBuzzEntity>(() => GetCalculateFizzBuzz(startNumber, limitNumber));
				fizzBuzzEntity.Start();
				return await fizzBuzzEntity;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				throw new FizzBuzzException("Failed GetFizzBuzzResult", exception);
			}
		}

		private FizzBuzzEntity GetCalculateFizzBuzz(int startNumber, int limitNumber)
		{
			try
			{
				var fizzBuzzEntity = new FizzBuzzEntity();
				for (var i = startNumber; i <= limitNumber; i++)
				{
					if (i % 3 == 0 && i % 5 == 0)
					{
						var fizzBuzz = "FizzBuzz";
						fizzBuzzEntity.FizzBuzzResults.Add(fizzBuzz);
						_logger.LogInformation($"{i} = {fizzBuzz}");
					}
					else if (i % 3 == 0)
					{
						var fizz = "Fizz";
						fizzBuzzEntity.FizzBuzzResults.Add(fizz);
						_logger.LogInformation($"{i} = {fizz}");
					}
					else if (i % 5 == 0)
					{
						var buzz = "Buzz";
						fizzBuzzEntity.FizzBuzzResults.Add(buzz);
						_logger.LogInformation($"{i} = {buzz}");
					}
					else
					{
						var number = i.ToString();
						fizzBuzzEntity.FizzBuzzResults.Add(number);
						_logger.LogInformation($"{i} = {number}");
					}
				}

				return fizzBuzzEntity;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				throw new FizzBuzzException("Failed GetCalculateFizzBuzz", exception);
			}
		}
	}
}
