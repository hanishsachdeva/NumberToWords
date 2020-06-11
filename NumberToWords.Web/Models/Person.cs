namespace NumberToWords.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Person" />.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter person name.")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Number.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        public decimal Number { get; set; }

        /// <summary>
        /// Gets or sets the Words.
        /// </summary>
        public string Words { get; set; }
    }
}
