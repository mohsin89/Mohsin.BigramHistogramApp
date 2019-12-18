using System;
using System.Collections.Generic;

namespace Mohsin.BigramHistogramApp
{
    class BigramHistogramApp
    {
        static void Main(string[] args)
        {
            bool validPath = false;
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("Hello & Welcome!");
            Console.WriteLine("Please enter a valid file path to begin:");

            // Determine whether the input is a valid file
            while (!validPath)
            {
                dataAccess.UserInput = Console.ReadLine();

                // 1. storing the file path 
                // 2. verify it is an accessible location and file
                validPath = dataAccess.ValidateFile();

                if (!validPath)
                    Console.WriteLine("File not found! Please try entering the complete file path again:");
            }

            Console.WriteLine("Processing...");


            // Read in valid text from the file
            string fileData = dataAccess.ReadFile();
            if (string.IsNullOrWhiteSpace(fileData))
                Console.WriteLine("Error: File data may be corrupt");

            // Pass off to historgram generator object
            Dictionary<string, int> histograms = 
                new HistogramGenerator(fileData)
                .Run();

            // Final failure check otherwise go to results output
            if (histograms != null)
            {
                Console.WriteLine("Results:");
                GetInstance.Write(histograms);
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
            }

            // End
        }


        // using singleton pattern
        private static readonly BigramHistogramApp instance = null;
        
        public static BigramHistogramApp GetInstance
        {
            get
            {
                return instance ?? new BigramHistogramApp();
            }
        }


        /// <summary>
        /// A simple method that takes in a Dictionary with string keys and integer values and writes them out
        /// </summary>
        /// <param name="hg">Histogram data in a Dictionary</param>
        private void Write(Dictionary<string, int> hg)
        {
            foreach (KeyValuePair<string, int> histogram in hg)
                Console.WriteLine($"\"{histogram.Key}\": {histogram.Value}");
        }


    }
}
