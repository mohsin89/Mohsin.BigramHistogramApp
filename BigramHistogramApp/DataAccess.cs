using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Mohsin.BigramHistogramApp
{
    public class DataAccess
    {
        // variables
        private string usersFile { get; set; }

        public string UserInput
        {
            get { return usersFile; }
            set { usersFile = value; }
        }


        /// <summary>
        /// Blank constructor
        /// </summary>
        public DataAccess()
        {
            
        }


        /// <summary>
        /// Check input is valid and verify the path to file exists
        /// </summary>
        /// <returns></returns>
        public bool ValidateFile()
        {
            // Check if file exists or if string is null or empty or whitespace
            if (string.IsNullOrWhiteSpace(UserInput) && UserInput != string.Empty)
                return false;

            if (File.Exists(UserInput))
                return true;

            return false;
        }


        /// <summary>
        /// Provides the text from the user provided file
        /// </summary>
        /// <returns></returns>
        public string ReadFile()
        {
            if (string.IsNullOrWhiteSpace(usersFile) && usersFile != string.Empty)
                return string.Empty;

            string allLines = string.Empty;
            try
            {
                allLines = File.ReadAllText(usersFile).Trim();
            }
            catch (Exception e)
            {
                return "File Not Found";
            }
            return CleanUpText(allLines);
        }


        /// <summary>
        /// Cleans up unwanted characters from a user-provided file
        /// Converts multi-line text from a file into a single line of text
        /// </summary>
        /// <param name="fileText">unmodified text from user-provided file</param>
        /// <returns>single line of text without punctuation, line breaks or tabs</returns>
        public string CleanUpText(string fileText)
        {
            string newText = Regex.Replace(fileText, @"\t|\n|\r|\e|[.]|[!]|[%]|[1-9]|[\\]|[//]", " ");
            return newText.Replace("  ", " ").ToLower();
        }
    }
}
