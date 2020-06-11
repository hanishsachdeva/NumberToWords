namespace NumberToWords.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NumberToWords.Service.Helper;
    using System;

    /// <summary>
    /// Defines the <see cref="AmountConverterTests" />.
    /// </summary>
    [TestClass]
    public class AmountConverterTests
    {
        /// <summary>
        /// The ConvertToWord_Negative.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Negative()
        {
            decimal amount = -1;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("negative ONE DOLLARS AND ZERO CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Zero.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Zero()
        {
            decimal amount = 0;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("ZERO DOLLARS and ZERO CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_lessThanOne.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_lessThanOne()
        {
            decimal amount = 0.29M;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("ZERO DOLLARS AND TWENTY-NINE CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_Ten.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_Ten()
        {
            decimal amount = 11;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("ELEVEN DOLLARS AND ZERO CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_Hundred.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_Hundred()
        {
            decimal amount = 110M;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("ONE HUNDRED AND TEN DOLLARS AND ZERO CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_DollorAndCents.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_DollorAndCents()
        {
            decimal amount = 65342.563M;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("SIXTY-FIVE THOUSAND AND THREE HUNDRED AND FORTY-TWO DOLLARS AND FIFTY-SIX CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_Million.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_Million()
        {
            decimal amount = 1234567.12M;
            string words = AmountConverter.ToWords(amount);

            Assert.AreEqual("ONE MILLION AND TWO HUNDRED AND THIRTY-FOUR THOUSAND AND FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND TWELVE CENTS", words, true);
        }

        /// <summary>
        /// The ConvertToWord_Input_VeryLarge.
        /// </summary>
        [TestMethod]
        public void ConvertToWord_Input_VeryLarge()
        {
            decimal amount = 12312345645678978956712345671.06M;
            OverflowException expectedExcetpion = null;

            try
            {
                AmountConverter.ToWords(amount);
            }
            catch (OverflowException ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }
    }
}
