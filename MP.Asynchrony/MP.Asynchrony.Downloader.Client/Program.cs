﻿using System;
using System.Windows.Forms;

namespace MP.Asynchrony.Downloader.Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIClient());
        }
    }
}
