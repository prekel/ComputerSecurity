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

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");
        private TextBox KeyTextBox => this.FindControl<TextBox>("KeyTextBox");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            RefreshKey();
        }

        private void RefreshKey()
        {
            Cipher = new MagicSquareCipher(new MagicSquare(KeyTextBox.Text));
        }

        private void OnRefreshKeyButtonClick(object sender, RoutedEventArgs e)
        {
            RefreshKey();
        }

        private void OnCryptButtonClick(object sender, RoutedEventArgs e)
        {
            var text = TextTextBox.Text;

            var ct = Cipher.Crypt(text);

            CiphertextTextBox.Text = ct;
        }

        private void OnEncryptButtonClick(object sender, RoutedEventArgs e)
        {
            var ct = CiphertextTextBox.Text;

            var text = Cipher.Encrypt(ct);

            TextTextBox.Text = text;
        }
    }
}