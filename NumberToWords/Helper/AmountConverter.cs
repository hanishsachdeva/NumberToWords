namespace NumberToWords.Service.Helper
{
    using System;

    /// <summary>
    /// Amount Converter.
    /// </summary>
    public static class AmountConverter
    {
        /// <summary>
        /// Defines the ones.
        /// </summary>
        private static string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        /// <summary>
        /// Defines the tens.
        /// </summary>
        private static string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        /// <summary>
        /// Defines the thous.
        /// </summary>
        private static string[] thous = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };

        /// <summary>
        /// Defines the fmt_negative.
        /// </summary>
        private static string fmt_negative = "negative {0}";

        /// <summary>
        /// Defines the fmt_dollars_and_cents.
        /// </summary>
        private static string fmt_dollars = "{0} dollars";

        /// <summary>
        /// Defines the fmt_dollars_and_cents.
        /// </summary>
        private static string fmt_dollar = "{0} dollar";

        /// <summary>
        /// Defines the fmt_dollars_and_cents.
        /// </summary>
        private static string fmt_dollars_and_cents = "{0} dollars and {1} cents";

        /// <summary>
        /// Defines the fmt_dollars_and_cents.
        /// </summary>
        private static string fmt_cents = "{0} cents";

        /// <summary>
        /// Defines the fmt_tens_ones.
        /// </summary>
        private static string fmt_tens_ones = "{0}-{1}";// e.g. for twenty-one, thirty-two etc. You might want to use an en-dash or em-dash instead of a hyphen.

        /// <summary>
        /// Defines the fmt_large_small.
        /// </summary>
        private static string fmt_large_small = "{0} and {1}";// stitches together the large and small part of a number, like "{three thousand} {five hundred forty two}"

        /// <summary>
        /// Defines the fmt_amount_scale.
        /// </summary>
        private static string fmt_amount_scale = "{0} {1}";// adds the scale to the number, e.g. "{three} {million}";

        /// <summary>
        /// The ToWords.
        /// </summary>
        /// <param name="number">The number<see cref="decimal"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ToWords(decimal number)
        {
            if (number < 0)
                return string.Format(fmt_negative, ToWords(Math.Abs(number)));

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);

            //if(number == 0 || decPortion == 0)
            //{
            //    return string.Format(fmt_dollars, ToWords(Math.Abs(number)));
            //}

            //if (intPortion == 0 && decPortion > 0)
            //{
            //    return string.Format(fmt_cents, ToWords(Math.Abs(number)));
            //}

            return string.Format(fmt_dollars_and_cents, ToWords(intPortion), ToWords(decPortion)).ToUpper();
        }

        /// <summary>
        /// The ToWords.
        /// </summary>
        /// <param name="number">The number<see cref="int"/>.</param>
        /// <param name="appendScale">The appendScale<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string ToWords(int number, string appendScale = "")
        {
            string numString = "";
            // if the number is less than one hundred, then we're mostly just pulling out constants from the ones and tens dictionaries
            if (number < 100)
            {
                if (number < 20)
                    numString = ones[number];
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString = string.Format(fmt_tens_ones, numString, ones[number % 10]);
                }
            }
            else
            {
                int pow = 0; // we'll divide the number by pow to figure out the next chunk
                string powStr = ""; // powStr will be the scale that we append to the string e.g. "hundred", "thousand", etc.

                if (number < 1000)
                { // number is between 100 and 1000
                    pow = 100; // so we'll be dividing by one hundred
                    powStr = thous[0]; // and appending the string "hundred"
                }
                else
                { // find the scale of the number
                  // log will be 1, 2, 3 for 1_000, 1_000_000, 1_000_000_000, etc.
                    int log = (int)Math.Log(number, 1000);
                    // pow will be 1_000, 1_000_000, 1_000_000_000 etc.
                    pow = (int)Math.Pow(1000, log);
                    // powStr will be thousand, million, billion etc.
                    powStr = thous[log];
                }

                // we take the quotient and the remainder after dividing by pow, and call ToWords on each to handle cases like "{five thousand} {thirty two}" (curly brackets added for emphasis)
                numString = string.Format(fmt_large_small, ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            // and after all of this, if we were passed in a scale from above, we append it to the current number "{five} {thousand}"
            return string.Format(fmt_amount_scale, numString, appendScale).Trim();
        }
    }
}
