using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Lab_01.Core;
using MessageBox.Avalonia;

namespace Lab_01.App
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillerCharTextBox
                .GetObservable(TextBox.TextProperty)
                .Subscribe(text => OnRefreshKeyNeeded());
            KeyTextBox
                .GetObservable(TextBox.TextProperty)
                .Subscribe(text => OnRefreshKeyNeeded());
        }

        private MagicSquareCipher Cipher { get; set; }

        private bool IsRefreshKeyNeeded { get; set; } = true;

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");
        private TextBox FillerCharTextBox => this.FindControl<TextBox>("FillerCharTextBox");
        private TextBox KeyTextBox => this.FindControl<TextBox>("KeyTextBox");
        private ComboBox KeysComboBox => this.FindControl<ComboBox>("KeysComboBox");
        private CheckBox RemoveSpacesCheckBox => this.FindControl<CheckBox>("RemoveSpacesCheckBox");
        private CheckBox ToUpperCheckBox => this.FindControl<CheckBox>("ToUpperCheckBox");
        private CheckBox RemoveNonLettersCheckBox => this.FindControl<CheckBox>("RemoveNonLettersCheckBox");

        private void OnRefreshKeyNeeded()
        {
            IsRefreshKeyNeeded = true;
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
            if (!IsRefreshKeyNeeded)
            {
                return;
            }

            Cipher = new MagicSquareCipher(new MagicSquare(KeyTextBox.Text), FillerCharTextBox.Text.First());
            IsRefreshKeyNeeded = false;
        }

        private string TransformString(string text)
        {
            var ret = text;
            if (RemoveSpacesCheckBox.IsChecked != null && RemoveSpacesCheckBox.IsChecked.Value)
            {
                ret = ret.Replace(" ", "");
            }

            if (RemoveNonLettersCheckBox.IsChecked != null && RemoveNonLettersCheckBox.IsChecked.Value)
            {
                ret = new string(ret.Where(Char.IsLetter).ToArray());
            }

            if (ToUpperCheckBox.IsChecked != null && ToUpperCheckBox.IsChecked.Value)
            {
                ret = ret.ToUpperInvariant();
            }

            return ret;
        }

        private void OnCryptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshKey();

                var text = TransformString(TextTextBox.Text);

                var ct = Cipher.Crypt(text);

                CiphertextTextBox.Text = ct;
            }
            catch (Exception ex)
            {
                var msgBox = MessageBoxManager
                    .GetMessageBoxStandardWindow("Ошибка", ex.Message + "\n" + ex.StackTrace);
                msgBox.Show();
            }
        }

        private void OnEncryptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                RefreshKey();

                var ct = CiphertextTextBox.Text;

                var text = Cipher.Encrypt(ct);

                TextTextBox.Text = text;
            }
            catch (Exception ex)
            {
                var msgBox = MessageBoxManager
                    .GetMessageBoxStandardWindow("Ошибка", ex.Message + "\n" + ex.StackTrace);
                msgBox.Show();
            }
        }

        private void OnKeysComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KeyTextBox.Text = KeysComboBox.SelectedItem + "\n";
            IsRefreshKeyNeeded = true;
        }
    }
}
