using MP.Asynchrony.Common.Extentions;
using System;
using System.Linq;

namespace MP.Asynchrony.Common.OutputManagers
{
    public class ConsoleOutputManager : IOutputManager
    {
        private string _delimiterChar = "-";

        public void DisplayDelimeter()
        {
            var delimiterString = string.Join(_delimiterChar, Enumerable.Range(0, 50).Select(item => string.Empty));

            DisplayMessage(delimiterString);
        }

        public void DisplayException(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            Console.WriteLine(exception.GetFullExceptionMessage());
        }

        public void DisplayMessage(string outputText)
        {
            if (string.IsNullOrEmpty(outputText?.Trim()))
                throw new ArgumentNullException(nameof(outputText));

            Console.WriteLine(outputText);
        }
    }
}
