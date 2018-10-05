using System;

namespace MP.Asynchrony.Common.OutputManagers
{
    public interface IOutputManager
    {
        void DisplayMessage(string outputText);

        void DisplayDelimeter();

        void DisplayException(Exception exception);
    }
}
