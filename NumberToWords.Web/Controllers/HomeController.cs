namespace NumberToWords.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using NumberToWords.Web.Models;
    using NumberToWords.Web.Repositories;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="HomeController" />.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Defines the _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Defines the _homeRepository.
        /// </summary>
        private readonly IHomeRepository _homeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <param name="homeRepository">The homeRepository<see cref="IHomeRepository"/>.</param>
        public HomeController(IConfiguration configuration, IHomeRepository homeRepository)
        {
            _configuration = configuration;
            _homeRepository = homeRepository;
        }

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The ConvertToWord.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> ConvertToWord(Person person)
        {
            var baseUrl = _configuration.GetValue<string>("APIUrl");
            var words = await _homeRepository.GetNumberInWords(person.Number, baseUrl);
            person.Words = words;
            return View("~/Pages/Shared/Index.cshtml", person);
        }
    }
}
