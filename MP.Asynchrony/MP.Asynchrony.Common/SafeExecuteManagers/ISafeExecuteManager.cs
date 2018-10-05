using System;
using System.Threading.Tasks;

namespace MP.Asynchrony.Common.SafeExecuteManagers
{
    public interface ISafeExecuteManager
    {
        void ExecuteWithExceptionHandling(Action action);

        void ExecuteWithExceptionHandling(Func<Task> func);
    }
}
