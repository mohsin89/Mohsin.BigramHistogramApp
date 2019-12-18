using Xunit;

namespace Mohsin.BigramHistogramApp.Tests
{
    public class DataAccessTests
    {
        private DataAccess dataAccess;

        public DataAccessTests()
        {
            dataAccess = new DataAccess();
        }

        [Fact]
        public void ValidateFile_NullParam()
        {
            bool result = dataAccess.ValidateFile();
            Assert.False(result);
        }

        [Fact]
        public void ValidateFile_WhitespaceInput()
        {
            dataAccess.UserInput = " ";
            bool result = dataAccess.ValidateFile();
            Assert.False(result);
        }

        [Fact]
        public void ValidateFile_ValidPathToDefaultUserAccount()
        {
            dataAccess.UserInput = "C:\\Users\\Default\\NTUSER.DAT";
            bool result = dataAccess.ValidateFile();
            Assert.True(result);
        }

        [Fact]
        public void ReadFile_NullParam()
        {
            string result = dataAccess.ReadFile();
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ReadFile_WhitespaceInput()
        {
            dataAccess.UserInput = " ";
            string result = dataAccess.ReadFile();
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ReadFile_ValidInput()
        {
            dataAccess.UserInput = "C:\\Temp\\data.txt";
            string result = dataAccess.ReadFile();
            Assert.Equal("File Not Found", result);
        }

        [Fact]
        public void CleanUpFile_RemovedPunctuation()
        {
            string input = "Hello.There  will be! no. punctuation.1 Gone! These too!";
            string result = dataAccess.CleanUpText(input);
            Assert.Equal("hello there will be no punctuation  gone these too ", result);
        }

    }
}
