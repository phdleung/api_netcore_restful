using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APICoreRestful.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CalculatorController : ControllerBase
  {
    [HttpGet("{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }

      return BadRequest("Invalid request");
    }

    private decimal ConvertToDecimal(string number)
    {
      decimal decimalValue;

      if (decimal.TryParse(number, out decimalValue))
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
