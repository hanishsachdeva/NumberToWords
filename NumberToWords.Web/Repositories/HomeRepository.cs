namespace NumberToWords.Web.Repositories
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="HomeRepository" />.
    /// </summary>
    public class HomeRepository : IHomeRepository
    {
        /// <summary>
        /// Defines the _client.
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class.
        /// </summary>
        public HomeRepository()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// The GetNumberInWords.
        /// </summary>
        /// <param name="number">The number<see cref="decimal"/>.</param>
        /// <param name="baseUrl">The baseUrl<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{string}"/>.</returns>
        public async Task<string> GetNumberInWords(decimal number, string baseUrl)
        {
            _client.BaseAddress = new Uri(baseUrl);
            string url = $"{number}";
            var response = await _client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
