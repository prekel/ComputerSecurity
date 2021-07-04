﻿using Avalonia;

namespace Lab_03.App
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
