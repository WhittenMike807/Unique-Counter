using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTableExt;
namespace Unique_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Today the concept of service mesh is on the rise and when you try Istio, an implementation of this concept, you instantly understand why. This mesh concept shines especially when you have a microservice approach. But with all your services, sometimes you want to use a solution like Let’s Encrypt to automate certificate creation. And if you are on a Kubernetes cluster, you will end up finding a Cert-Manager project that can link your cluster to Let’s Encrypt when you need a certificate. Now you know what to do, and when you use Istio, the documentation will help you achieve what you want.But sometime, what you understand from the web, might not explain much what really behind the curtain(this example).I hope this post to be helpful for you if you want to understand what is going on when you integrate Let’s Encrypt(via cert-manager) with Istio ingress gateway. Here, I will speak about cert - manager then Istio for you to understand the theory.On the later part, I will give an example for you to follow.It will help you discover while building your own cluster.";

            WordCountHelper helper = new WordCountHelper();

            ConsoleTableBuilder.From(helper.WordsCountList(text)).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();
            //Console.ReadKey();
        }

        

    }

    public class WordCountHelper
    {
        public WordCountHelper()
        {
        }

        /// <summary>
        /// Long string inputs are split into an string array, grouped, selected into a new WordCount class, ordered by count **desc, then ordered by the word, and finally it returns a list.
        /// </summary>
        /// <param name="paragraphText"></param>
        /// <returns></returns>
        public List<WordCount> WordsCountList(string paragraphText)
        {

            string[] wordList = paragraphText.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            return wordList
                .GroupBy(x => x.ToLower())
                .Select(x => new WordCount
                {
                    Word = new string(CharsToTitleCase(x.Key).ToArray()),
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Word)
                .ToList();
        }

        /// <summary>
        /// This is to just help with the display of the console table formating.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IEnumerable<char> CharsToTitleCase(string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == ' ')
                {
                    newWord = true;
                }
            }
        }
    }

    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
