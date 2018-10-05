using System;
using System.Linq;
using System.Windows.Forms;

namespace MP.Asynchrony.Common.OutputManagers
{
    public class WinFormOutputManager : IOutputManager
    {
        private string _delimiterChar = "-";

        public Label OutSource { private get; set; }

        public void DisplayDelimeter()
        {
            var delimiterString = string.Join(_delimiterChar, Enumerable.Range(0, 50).Select(item => string.Empty));

            DisplayMessage(delimiterString);
        }

        public void DisplayException(Exception exception)
        {
            if (OutSource == null)
                throw new ArgumentNullException("OutSource is not set");

            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            OutSource.Text = exception.Message;
        }

        public void DisplayMessage(string outputText)
        {
            if (OutSource == null)
                throw new ArgumentNullException("OutSource is not set");

            if (string.IsNullOrEmpty(outputText?.Trim()))
                throw new ArgumentNullException(nameof(outputText));

            OutSource.Text = outputText.Trim();
        }
    }
}
