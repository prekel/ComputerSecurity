using System;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
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
        private ComboBox KeysComboBox => this.FindControl<ComboBox>("KeysComboBox");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            if (!File.Exists(MagicSquares.Filename))
            {
                MagicSquares.Save();
            }
            
            KeysComboBox.Items = MagicSquares.Load()
                .Replace("\r", "")
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

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

        private void OnKeysComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KeyTextBox.Text = KeysComboBox.SelectedItem + "\n";
        }
    }
}