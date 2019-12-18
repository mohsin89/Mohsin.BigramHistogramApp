using System;
using System.Collections.Generic;

namespace Mohsin.BigramHistogramApp
{
    public class HistogramGenerator
    {
        /// <summary>
        /// Variable to store text for conversion to bigrams
        /// </summary>
        private string userText = string.Empty;

        /// <summary>
        /// Class constructor. Must be initialized with
        /// </summary>
        /// <param name="readableText"></param>
        public HistogramGenerator(string readableText)
        {
            if (string.IsNullOrEmpty(readableText))
                throw new ArgumentException("Object cannot be instantiated with invalid or missing input!");

            userText = readableText;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> Run()
        {
            // check for no input
            if (string.IsNullOrEmpty(userText))
                return null;

            // Process text into bigrams
            string[] _bigrams = FindBigrams(userText);

            // Convert into historgrams
            Dictionary<string, int> resultsData = CreateHistogram(_bigrams);

            return resultsData;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="textToParse"></param>
        /// <returns></returns>
        public string[] FindBigrams(string textToParse)
        {
            List<string> bigrams = new List<string>();

            // split the input on whitespace to be able to select individual words
            // and ignore any resulting blank elements
            foreach (string word in textToParse.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                // dont update previous element on first word
                // otherwise always add so you get Word1 + Word2
                if (bigrams.Count > 0)
                    bigrams[bigrams.Count - 1] += string.Concat(" ", word);

                // add the word as a new element
                bigrams.Add(word);
            }

            // ensure each key has two words
            // remove any with one word, which can occur at end of sentence or text input
            bigrams.RemoveAll(bigram => (bigram.Split(' ').Length < 2));

            return bigrams.ToArray();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bigramsArray"></param>
        /// <returns></returns>
        public Dictionary<string, int> CreateHistogram(string[] bigramsArray)
        {
            Dictionary<string, int> hs = new Dictionary<string, int>();

            // iterate through array passed in
            foreach (string bigram in bigramsArray)
            {
                // this line ensures no duplicate keys in the dictionary
                if (hs.ContainsKey(bigram.ToLower()))
                {
                    hs[bigram] += 1;
                }
                else
                {
                    // add a unique bigram to the dictionary
                    hs.Add(bigram.ToLower(), 1);
                }
            }

            return hs;
        }
    }
}
