using System;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Lab_01.Core;

namespace Lab_01.App
{
    public class MainWindow : Window
    {
        private MagicSquareCipher Cipher { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            Cipher = new MagicSquareCipher(
                new MagicSquare(
                    this.FindControl<TextBox>("KeyTextBox").Text
                    )
                );
        }

        private void OnCryptButtonClick(object sender, RoutedEventArgs e)
        {
            var textTextBox = this.FindControl<TextBox>("TextTextBox");
            var ciphertextTextBox = this.FindControl<TextBox>("CiphertextTextBox");
            var text = textTextBox.Text;

            var ct = Cipher.Crypt(text);

            ciphertextTextBox.Text = ct;
        }

        private void OnEncryptButtonClick(object sender, RoutedEventArgs e)
        {
            var textTextBox = this.FindControl<TextBox>("TextTextBox");
            var ciphertextTextBox = this.FindControl<TextBox>("CiphertextTextBox");
            var ct = textTextBox.Text;

            var text = Cipher.Encrypt(ct);

            textTextBox.Text = text;
        }
    }
}