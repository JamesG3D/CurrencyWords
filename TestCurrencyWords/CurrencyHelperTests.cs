using System;
using NUnit.Framework;
using static currencyWords.CurrencyHelper;

namespace TestCurrencyWords
{
    [TestFixture]
    public class CurrencyHelperTests
    {
        [Test]
        public void Test1_15()
        {
            Assert.AreEqual("One Dollar and Fifteen Cents", CreateCurrencyString("$1.15"));
        }
        
        [Test]
        public void Test1500()
        {
            Assert.AreEqual("One Thousand Five Hundred Dollars", CreateCurrencyString("$1,500.0"));
        }
        
        [Test]
        public void Test150000_50()
        {
            Assert.AreEqual("One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("150000.50"));
        }
        
        [Test]
        public void Test1150000_50()
        {
            Assert.AreEqual("One Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("1,150,000.50"));
        }
        
        [Test]
        public void Test11150000_50()
        {
            Assert.AreEqual("Eleven Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("11,150,000.50"));
        }
        
        [Test]
        public void Test111150000_50()
        {
            Assert.AreEqual("One Hundred and Eleven Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("111,150,000.50"));
        }
        
        [Test]
        public void Test1111150000_50()
        {
            Assert.AreEqual("One Billion One Hundred and Eleven Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("1,111,150,000.50"));
        }
        
        [Test]
        public void Test1001111150000_50()
        {
            Assert.AreEqual("One Trillion and One Billion One Hundred and Eleven Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("1,001,111,150,000.50"));
        }
        
        [Test]
        public void Test101001111150000_50()
        {
            Assert.AreEqual("One Hundred and One Trillion and One Billion One Hundred and Eleven Million One Hundred and Fifty Thousand Dollars and Fifty Cents", CreateCurrencyString("101,001,111,150,000.50"));
        }

        [Test]
        public void Test123456()
        {
            Assert.AreEqual("One Hundred and Twenty Three Thousand Four Hundred and Fifty Six Dollars", CreateCurrencyString("123456"));
        }
        
        [Test]
        public void Test123456789_10()
        {
            Assert.AreEqual("One Hundred and Twenty Three Million Four Hundred and Fifty Six Thousand Seven Hundred and Eighty Nine Dollars and Ten Cents", CreateCurrencyString("123,456,789.10"));
        }
    }
}