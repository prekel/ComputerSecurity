using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MessageBox.Avalonia;

namespace Lab_02.App
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
            RefreshKey();
        }

        private bool IsRefreshKeyNeeded { get; set; } = true;

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");
        private TextBox FillerCharTextBox => this.FindControl<TextBox>("FillerCharTextBox");
        private TextBox KeyTextBox => this.FindControl<TextBox>("KeyTextBox");
        private ComboBox KeysComboBox => this.FindControl<ComboBox>("KeysComboBox");
        private CheckBox RemoveSpacesCheckBox => this.FindControl<CheckBox>("RemoveSpacesCheckBox");
        private CheckBox ToUpperCheckBox => this.FindControl<CheckBox>("ToUpperCheckBox");
        private CheckBox RemoveNonLettersCheckBox => this.FindControl<CheckBox>("RemoveNonLettersCheckBox");
        private TextBlock MagicSquareInfoTextBlock => this.FindControl<TextBlock>("MagicSquareInfoTextBlock");

        private void OnRefreshKeyNeeded()
        {
            IsRefreshKeyNeeded = true;
            MagicSquareInfoTextBlock.Text = " ";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            try
            {
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void RefreshKey()
        {
            try
            {
                if (!IsRefreshKeyNeeded)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
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
                RefreshKey();

                var ct = CiphertextTextBox.Text;

            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnRotateButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnKeysComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KeyTextBox.Text = KeysComboBox.SelectedItem + "\n";
            IsRefreshKeyNeeded = true;
            RefreshKey();
        }

        private void ExceptionMessageBox(Exception ex)
        {
            var msgBox = MessageBoxManager
                .GetMessageBoxStandardWindow("Ошибка", ex.Message + "\n" + ex.StackTrace);
            msgBox.Show();
        }
    }
}
