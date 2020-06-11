namespace NumberToWords.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NumberToWords.Service.Helper;
    using System;

    /// <summary>
    /// Defines the <see cref="AmountConverterController" />.
    /// </summary>
    [ApiController]
    [Route("api/amountconverter")]
    public class AmountConverterController : ControllerBase
    {
        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="number">The number<see cref="decimal"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet]
        [Route("{number:decimal}")]
        public IActionResult Get(decimal number)
        {
            try
            {
                string words = string.Empty;
                if (number > 0)
                {
                    words = AmountConverter.ToWords(number);
                }

                return Ok(words);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
