using MP.Asynchrony.Common.OutputManagers;
using System;

namespace MP.Asynchrony.Common.InputManagers
{
    public class ConsoleInputManager : IInputManager
    {
        private readonly IOutputManager _outputManager;

        public ConsoleInputManager(IOutputManager outputManager)
        {
            _outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        }

        public double GetInputNumericValue()
        {
            var isSuccess = false;
            var stringValue = GetInputStringValue();

            while (!isSuccess)
            {
                if (!double.TryParse(stringValue, out var doubleValue))
                {
                    _outputManager.DisplayMessage("Input value is not a number. Please, try again.");
                    stringValue = GetInputStringValue();
                }
                else
                {
                    isSuccess = true;
                }
            }

            return double.Parse(stringValue);
        }

        public string GetInputStringValue()
        {
            var isSuccess = false;
            var value = Console.ReadLine().Trim();

            while (!isSuccess)
            {
                if (string.IsNullOrEmpty(value))
                {
                    _outputManager.DisplayMessage("Empty input value. Please, try again.");
                    value = Console.ReadLine().Trim();
                }
                else
                {
                    isSuccess = true;
                }
            }

            return value;
        }
    }
}
