namespace NumberToWords.Web.Repositories
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IHomeRepository" />.
    /// </summary>
    public interface IHomeRepository
    {
        /// <summary>
        /// The GetNumberInWords.
        /// </summary>
        /// <param name="number">The number<see cref="decimal"/>.</param>
        /// <param name="baseUrl">The baseUrl<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        Task<string> GetNumberInWords(decimal number, string baseUrl);
    }
}
