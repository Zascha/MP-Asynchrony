using System;
using System.Windows.Forms;

namespace MP.Asynchrony.Common.InputManagers
{
    public class WinFormInputManager : IInputManager
    {
        public TextBox Source { get; set; }

        public double GetInputNumericValue()
        {
            var stringValue = GetInputStringValue();

            if(!double.TryParse(stringValue, out var doubleValue))
            {
                throw new ArgumentException("Pathed value is not numeric.");
            }

            return double.Parse(stringValue);
        }

        public string GetInputStringValue()
        {
            if (Source == null)
                throw new ArgumentNullException("Input source is not set");

            return Source.Text.Trim();
        }
    }
}
