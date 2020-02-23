using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace currencyWords
{
    public class CurrencyHelper
    {
        private static Dictionary<int, string> SmallNumberNames = new Dictionary<int, string>
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
        };

        private static Dictionary<int, string> BigNumberNames = new Dictionary<int, string>
        {
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"},
        };

        /// <summary>
        /// Takes a dollar amount to convert it to its English currency representation in words.
        /// </summary> 
        /// <remarks>
        /// The amount string must have only one dot ('.') to be used to separate dollars from cents. All other non-numeric characters are ignored.
        /// </remarks>
        /// <returns>
        /// English currency representation of the amount in words; in short scale.
        /// </returns>
        public static String CreateCurrencyString(String amount)
        {
            if (amount.Length > 100)
                return "Zimbabwean dollar not supported.";

            String currencyAsWords = "";

            bool negative = amount.Trim().StartsWith("-");

            // remove the currency symbol and sign etc.
            amount = Regex.Replace(amount, "[^0-9\\.]", "");

            // split into dollars and cents
            String[] amounts = amount.Split('.');

            if (amounts.Length > 2)
                return "Expected '.' to be used only once, for decimal point";

            if (amounts[0] == "1")
                currencyAsWords += " Dollar";
            else if (amounts[0] == "" || long.Parse(amounts[0]) == 0)
                currencyAsWords += "Zero Dollars";
            else
                currencyAsWords += " Dollars";

            //handle cents(rounded to 2 dp)
            if (amounts.Length > 1)
            {
                Double centsAmount = Math.Round(double.Parse("0." + amounts[1]), 2);
                if (centsAmount > 0)
                    currencyAsWords += " and " + CreateNumberString(centsAmount.ToString("N2").Substring(2)) + " Cents";
            }

            currencyAsWords = CreateNumberString(amounts[0]) + currencyAsWords;

            if (negative)
                currencyAsWords = "Negative " + currencyAsWords;

            //remove double spaces
            currencyAsWords = Regex.Replace(currencyAsWords, "\\s\\s\\s*", " ");

            return currencyAsWords;
        }

        private static String CreateNumberString(String amount)
        {
            String numberAsWords = "";
            int placeValuePos = amount.Length;
            while (placeValuePos > 0)
            {
                if (placeValuePos > 12)
                {
                    //trillions
                    String numberString =
                        CreateNumberString(amount.Substring(amount.Length - placeValuePos, placeValuePos - 12));
                    if (numberString != "")
                        numberAsWords += numberString + " Trillion ";
                    placeValuePos = 12;
                }
                else if (placeValuePos > 9)
                {
                    //billions
                    String numberString =
                        CreateNumberString(amount.Substring(amount.Length - placeValuePos, placeValuePos - 9));
                    if (numberString != "")
                        numberAsWords += numberString + " Billion ";
                    placeValuePos = 9;
                }
                else if (placeValuePos > 6)
                {
                    //millions
                    String numberString =
                        CreateNumberString(amount.Substring(amount.Length - placeValuePos, placeValuePos - 6));
                    if (numberString != "")
                        numberAsWords += numberString + " Million ";
                    placeValuePos = 6;
                }
                else if (placeValuePos > 3)
                {
                    //thousands
                    String numberString =
                        CreateNumberString(amount.Substring(amount.Length - placeValuePos, placeValuePos - 3));
                    if (numberString != "")
                        numberAsWords += numberString + " Thousand ";
                    placeValuePos = 3;
                }
                else if (placeValuePos > 2)
                {
                    //hundreds
                    String numberString =
                        CreateNumberString(amount.Substring(amount.Length - placeValuePos, placeValuePos - 2));
                    if (numberString != "")
                        numberAsWords += numberString + " Hundred";
                    placeValuePos = 2;
                }
                else
                {
                    //tens
                    int tens = Int32.Parse(amount.Substring(amount.Length - placeValuePos));

                    if (amount.Length > 2 && tens > 0)
                        numberAsWords += " and ";

                    if (tens > 19)
                    {
                        numberAsWords +=
                            (BigNumberNames[Int32.Parse(amount.Substring(amount.Length - placeValuePos, 1) + "0")]);

                        int ones = Int32.Parse(amount.Substring(amount.Length - placeValuePos + 1));
                        if (ones > 0)
                            numberAsWords += " " + SmallNumberNames[ones];
                    }
                    else if (tens > 0)
                    {
                        numberAsWords += SmallNumberNames[tens];
                    }

                    placeValuePos = 0;
                }
            }

            return numberAsWords;
        }
    }
}