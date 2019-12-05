using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Unique_Counter.Tests
{
    [TestFixture]
    public class TestClass
    {
        [TestCase]
        public void ListsCountTest()
        {
            WordCountHelper helper = new WordCountHelper();
            IList<WordCount> expected = new List<WordCount>();
            expected.Add(new WordCount() { Word = "Taco", Count = 3 });
            List<WordCount> actual = helper.WordsCountList("Taco Taco taco");
            
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.IsTrue(actual[0].Count == 3);
        }

        [TestCase]
        public void FirstObjectCountTest()
        {
            WordCountHelper helper = new WordCountHelper();
            List<WordCount> actual = helper.WordsCountList("Blue is Blue");

            Assert.IsTrue(actual.Count() == 2);
            Assert.IsTrue(actual[0].Count == 2);
        }

        [TestCase]
        public void SingleSpaceTest()
        {
            WordCountHelper helper = new WordCountHelper();
            var text = new string(helper.CharsToTitleCase("h ello World").ToArray());

            Assert.IsTrue(text == "H Ello World");
        }
        [TestCase]
        public void DoubleSpaceTest()
        {
            WordCountHelper helper = new WordCountHelper();
            var text = new string(helper.CharsToTitleCase("h  ello world").ToArray());

            
            Assert.IsTrue(text == "H  Ello World");
        }
    }
}