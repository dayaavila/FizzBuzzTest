using System;
using System.Threading.Tasks;
using FizzBuzzTest.Domain.Interfaces;
using FizzBuzzTest.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FizzBuzzTest.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FizzBuzzController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<FizzBuzzController> _logger;
		private readonly IFizzBuzzService _fizzBuzzService;

		public FizzBuzzController(
			IConfiguration configuration,
			ILogger<FizzBuzzController> logger, 
			IFizzBuzzService fizzBuzzService)
		{
			_configuration = configuration;
			_logger = logger;
			_fizzBuzzService = fizzBuzzService;
		}

		[HttpGet]
		public async Task<ActionResult<FizzBuzzEntity>> GetFizzBuzz(int startNumber)
		{
			try
			{
				var limitNumber = Convert.ToInt32(_configuration["LimitNumber"]);
				_logger.LogInformation($"FizzBuzz Operation with startNumber: {startNumber} and limitNumber: {limitNumber} Started");
				var fizzBuzzResult = await _fizzBuzzService.GetFizzBuzzResult(startNumber, limitNumber);
				_logger.LogInformation("FizzBuzz Operation Completed");
				return Ok(fizzBuzzResult);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				return Problem("A problem has happened...");
			}
			
		}
	}
}
