﻿using Avalonia;
using Avalonia.Logging.Serilog;

namespace Lab_01.App
{
    internal class Program
    {
        public static void Main(string[] args) =>
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
    }
}
