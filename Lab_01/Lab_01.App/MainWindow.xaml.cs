using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab_01.App
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}