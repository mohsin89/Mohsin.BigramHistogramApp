using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Mohsin.BigramHistogramApp.Tests
{
    public class HistogramGeneratorTests
    {
        private HistogramGenerator histogramGenerator;

        public HistogramGeneratorTests()
        {
            histogramGenerator = new HistogramGenerator("test data");
        }

        [Fact]
        public void Constructor_NullParam()
        {
            var result = Assert.Throws<ArgumentException>(() => new HistogramGenerator(null));
            Assert.Equal("Object cannot be instantiated with invalid or missing input!", result.Message);
        }

        [Fact]
        public void GetSimpleBigram()
        {
            string sample = "hello world";
            string[] result = histogramGenerator.FindBigrams(sample);

            Assert.Single(result);
            Assert.Equal("hello world", result[0]);
        }

        [Fact]
        public void GetAdvancedBigram()
        {
            string sample = "oh who lives in a pineapple under the sea spongebob square pants";
            string[] result = histogramGenerator.FindBigrams(sample);

            Assert.Equal("oh who", result[0]);
            Assert.Equal("square pants", result[result.Length - 1]);
        }

        [Fact]
        public void GetHistogram()
        {
            // step 1
            string sample = "oh who lives in a pineapple under the sea spongebob square pants";
            string[] bigrams = histogramGenerator.FindBigrams(sample);
            // step 2
            Dictionary<string, int> histogram = histogramGenerator.CreateHistogram(bigrams);
            Assert.Equal(11, histogram.Count);
            Assert.True(histogram.ContainsKey("pineapple under"));
        }
    }
}

