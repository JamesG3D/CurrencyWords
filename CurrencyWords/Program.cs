using System;
using System.Diagnostics;

namespace currencyWords
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                Console.WriteLine(CurrencyHelper.CreateCurrencyString(args[0]));
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine(
                            "Enter a dollar amount to convert it to its English currency representation in words(in short scale).");
                        Console.WriteLine(CurrencyHelper.CreateCurrencyString(Console.ReadLine()));
                    }
                    catch (Exception e)
                    {
#if DEBUG
                        Console.WriteLine(e);
#endif
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}