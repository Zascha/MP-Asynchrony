using MP.Asynchrony.Common.InputManagers;
using MP.Asynchrony.Common.OutputManagers;
using System;

namespace MP.Asynchrony.Counter.Client
{
    public class MenuManager
    {
        private readonly IOutputManager _outputManager;
        private readonly IInputManager _inputManger;

        public MenuManager(IOutputManager outputManager, IInputManager inputManger)
        {
            _outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
            _inputManger = inputManger ?? throw new ArgumentNullException(nameof(inputManger));
        }

        public (double start, double limit) AskForCalculatingValues()
        {
            var start = AskForNumericValue("Please, input start value.");
            var limit = AskForNumericValue("Please, input limit value.");

            return (start, limit);
        }

        public double DisplayStartingCalculatingMessage()
        {
            _outputManager.DisplayMessage("Starting calculating... ");
            _outputManager.DisplayMessage("Please, wait till finish or input new values:");

            return _inputManger.GetInputNumericValue();
        }

        public void DisplayResultMessage((double start, double limit) values, double result)
        {
            _outputManager.DisplayMessage($"Sum from {values.start} to {values.limit}: {result}");
        }

        #region Private methods

        private double AskForNumericValue(string askingMessage)
        {
            _outputManager.DisplayMessage(askingMessage);

            return _inputManger.GetInputNumericValue();
        }

        #endregion
    }
}
