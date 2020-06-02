using System;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MessageBox.Avalonia;

namespace Lab_03.App
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnCryptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnEncryptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private static void ExceptionMessageBox(Exception ex)
        {
            var msgBox = MessageBoxManager
                .GetMessageBoxStandardWindow("Ошибка", ex.Message + "\n" + ex.StackTrace);
            msgBox.Show();
        }
    }
}
