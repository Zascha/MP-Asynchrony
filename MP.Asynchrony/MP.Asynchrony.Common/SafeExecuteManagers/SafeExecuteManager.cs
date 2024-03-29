﻿using MP.Asynchrony.Common.OutputManagers;
using System;
using System.Threading.Tasks;

namespace MP.Asynchrony.Common.SafeExecuteManagers
{
    public class SafeExecuteManager : ISafeExecuteManager
    {
        private readonly IOutputManager _outputManager;

        public SafeExecuteManager(IOutputManager outputManager)
        {
            _outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        }

        public void ExecuteWithExceptionHandling(Action action)
        {
            try
            {
                action();
            }
            catch(Exception exception)
            {
                _outputManager.DisplayException(exception);
            }
        }

        public void ExecuteWithExceptionHandling(Func<Task> func)
        {
            try
            {
                func().Wait();
            }
            catch (Exception exception)
            {
                _outputManager.DisplayException(exception);
            }
        }
    }
}
