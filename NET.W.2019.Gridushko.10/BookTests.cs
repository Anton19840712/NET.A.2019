namespace NET.W._2019.Gridushko._10
{
    using System;
    using System.Collections.Generic;
    using BooksLibrary.Formatters;
    using NUnit.Framework;

    [TestFixture]
    public class BookTests
    {
        public static IEnumerable<TestCaseData> ToStringTestCaseData
        {
            get
            {
                yield return new TestCaseData("AT").Returns("Jeffrey Richter, CLR via C#");
                yield return new TestCaseData("ATPY").Returns("Jeffrey Richter, CLR via C#, Microsoft Press, 2019");
                yield return new TestCaseData("IATP").Returns("ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press");
                yield return new TestCaseData("IATPYC").Returns("ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, Microsoft Press, 2019, $90");
            }
        }

        public static IEnumerable<TestCaseData> ToStringExtensionTestCaseData
        {
            get
            {
                yield return new TestCaseData("AC").Returns("Jeffrey Richter, $90");
                yield return new TestCaseData("TN").Returns("CLR via C#, 826");
            }
        }

        [Test, TestCaseSource(nameof(ToStringTestCaseData))]
        public string BookToStringTests(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2019", 826, 90m);
            return book.ToString(format);
        }

        [Test, TestCaseSource(nameof(ToStringExtensionTestCaseData))]
        public string BookToStringExtensionTests(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2019", 826, 90m);
            return string.Format(new BookFormatter(), "{0:" + format + "}", book);
        }

        [TestCase("KK")]
        [TestCase("IA")]
        [TestCase("NA")]
        public void BookToString_ThrowFormatException(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2019", 826, 90m);

            Assert.Throws<FormatException>(() => book.ToString(format));
        }

        [TestCase("KK")]
        [TestCase("IA")]
        [TestCase("NA")]
        public void BookToStringExtension_ThrowFormatException(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2019", 826, 90m);

            Assert.Throws<FormatException>(() => string.Format(new BookFormatter(), "{0:" + format + "}", book));
        }
    }
}