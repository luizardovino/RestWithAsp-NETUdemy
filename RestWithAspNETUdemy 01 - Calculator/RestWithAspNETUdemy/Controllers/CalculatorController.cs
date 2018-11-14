using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNETUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
      
        // GET api/calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertoDecimal(firstNumber) + ConvertoDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertoDecimal(firstNumber) - ConvertoDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/division/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertoDecimal(firstNumber) / ConvertoDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertoDecimal(firstNumber) * ConvertoDecimal(secondNumber);
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/calculator/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var result = Math.Sqrt((double) ConvertoDecimal(number));
                return Ok(result.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertoDecimal(string number)
        {
            decimal decimalValue;
            if(decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
