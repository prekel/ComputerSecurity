using System;
using System.Linq;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Lab_03.Core;

using MessageBox.Avalonia;

namespace Lab_03.App
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private VigenereAnalysis VigenereAnalysis { get; set; } = new VigenereAnalysis("");

        private TextBox TextTextBox => this.FindControl<TextBox>("TextTextBox");
        private TextBox CiphertextTextBox => this.FindControl<TextBox>("CiphertextTextBox");
        private ComboBox VariantsComboBox => this.FindControl<ComboBox>("VariantsComboBox");
        private ComboBox MuComboBox => this.FindControl<ComboBox>("MuComboBox");
        private TextBox MostOcurredLettersTextBox => this.FindControl<TextBox>("MostOcurredLettersTextBox");
        private TextBox KeyTextBox => this.FindControl<TextBox>("KeyTextBox");

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            VariantsComboBox.Items = Enumerable.Range(1, Variants.GetVariantsCount());
        }


        private void OnVariantsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CiphertextTextBox.Text = Variants.GetVariantByNumber((int) VariantsComboBox.SelectedItem);
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnMuComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MuComboBox.SelectedItem == null)
                {
                    return;
                }

                VigenereAnalysis.SuggestMu((int) MuComboBox.SelectedItem);
                KeyTextBox.Text = VigenereAnalysis.VigenereDecrypter.Key;
                MostOcurredLettersTextBox.Text = new string('О', VigenereAnalysis.Mu);
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnPossibleMusButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VigenereAnalysis = new VigenereAnalysis(CiphertextTextBox.Text);
                var items = VigenereAnalysis.PossibleMus().ToList();
                MuComboBox.Items = items;
                MuComboBox.SelectedItem = items.First();

                VigenereAnalysis.SuggestMu(items.First());
                KeyTextBox.Text = VigenereAnalysis.VigenereDecrypter.Key;
                MostOcurredLettersTextBox.Text = new string('О', VigenereAnalysis.Mu);
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnSuggestMostOccuredButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                for (var i = 0; i < VigenereAnalysis.Mu; i++)
                {
                    VigenereAnalysis.SuggestMostOccuring(i, MostOcurredLettersTextBox.Text[i]);
                }

                KeyTextBox.Text = VigenereAnalysis.VigenereDecrypter.Key;
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
                VigenereAnalysis.VigenereDecrypter.Key = KeyTextBox.Text;
                TextTextBox.Text = VigenereAnalysis.VigenereDecrypter.Text;
                MostOcurredLettersTextBox.Text = VigenereAnalysis.MostOccuringLettets;
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnFixKeyButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VigenereAnalysis.FixKey(TextTextBox.Text);
                KeyTextBox.Text = VigenereAnalysis.VigenereDecrypter.Key;
                TextTextBox.Text = VigenereAnalysis.VigenereDecrypter.Text;
                MostOcurredLettersTextBox.Text = VigenereAnalysis.MostOccuringLettets;
            }
            catch (Exception ex)
            {
                ExceptionMessageBox(ex);
            }
        }

        private void OnCheckKeyButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VigenereAnalysis.VigenereDecrypter.Key =
                    Variants.GetAnswerByNumber((int) VariantsComboBox.SelectedItem);
                KeyTextBox.Text = VigenereAnalysis.VigenereDecrypter.Key;
                TextTextBox.Text = VigenereAnalysis.VigenereDecrypter.Text;
                MostOcurredLettersTextBox.Text = VigenereAnalysis.MostOccuringLettets;
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
