using MP.Asynchrony.Common.OutputManagers;
using System;
using System.IO;

namespace MP.Asynchrony.Common
{
    public static class FileSystemHelper
    {
        public static string OutputDownloadDirectory { get; set; } = @"D:\Downloads";

        public static string FormOutputDownloadPath(string fileName, IOutputManager outputManager = null)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                if (outputManager != null)
                {
                    outputManager.DisplayMessage("No file name is set");
                }
                else throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
            {
                if (outputManager != null)
                {
                    outputManager.DisplayMessage("No file extension is set");
                }
                else throw new ArgumentException("No file extension is set");
            }

            if (!Directory.Exists(OutputDownloadDirectory))
            {
                Directory.CreateDirectory(OutputDownloadDirectory);
            }

            return Path.Combine(OutputDownloadDirectory, fileName);
        }
    }
}
