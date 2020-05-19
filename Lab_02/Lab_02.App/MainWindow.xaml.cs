using System;
using System.Linq;
using System.Numerics;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Lab_02.Core;

using MessageBox.Avalonia;

namespace Lab_02.App
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RsaDecrypter = new RsaDecrypter(31);
            RsaCrypter = new RsaCrypter(RsaDecrypter.OpenKey);
        }

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");

        private RsaDecrypter RsaDecrypter { get; }
        private RsaCrypter RsaCrypter { get; }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnCryptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CiphertextTextBox.Text = String.Join(", ", RsaCrypter.Crypt(TextTextBox.Text).Select(p => p));
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
                TextTextBox.Text =
                    RsaDecrypter.Decrypt(CiphertextTextBox.Text.Split(new[] {",", " "},
                        StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse));
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
