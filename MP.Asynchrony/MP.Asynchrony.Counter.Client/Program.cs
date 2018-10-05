using MP.Asynchrony.Common.InputManagers;
using MP.Asynchrony.Common.OutputManagers;
using MP.Asynchrony.Common.SafeExecuteManagers;
using System;

namespace MP.Asynchrony.Counter.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var _outputManager = new ConsoleOutputManager();
            var _inputManager = new ConsoleInputManager(_outputManager);
            var _safeExecutor = new SafeExecuteManager(_outputManager);

            var menu = new MenuManager(_outputManager, _inputManager);
            var counter = new SumCounter();

            //ToTestRecalculating(counter, menu);

            var values = menu.AskForCalculatingValues();

            _safeExecutor.ExecuteWithExceptionHandling(() =>
            {
                counter.CalculateSumAsync((int)values.start, (int)values.limit).ContinueWith(result => menu.DisplayResultMessage(values, result.Result));
            });

            menu.DisplayStartingCalculatingMessage();

            Console.ReadLine();
        }

        private static void ToTestRecalculating(SumCounter counter, MenuManager menu)
        {
            counter.CalculateSumAsync(0, int.MaxValue).ContinueWith(result => menu.DisplayResultMessage((0, int.MaxValue), result.Result));
            counter.CalculateSumAsync(0, 50).ContinueWith(result => menu.DisplayResultMessage((0, 50), result.Result));

            Console.ReadKey();
        }
    }
}
