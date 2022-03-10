using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab7zadachaWpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontSize = Convert.ToDouble(fontSize);
            }
        }

        bool Bold = false;
        private void Button_Bold(object sender, RoutedEventArgs e)
        {
            if (!Bold)
            {
                textBox.FontWeight = FontWeights.Bold;
                Bold = true;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
                Bold = false;
            }
        }

        bool Italic = false;
        private void Button_Italic(object sender, RoutedEventArgs e)
        {
            if (!Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
                Italic = true;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
                Italic = false;
            }
        }

        bool Underline = false;
        private void Button_Underline(object sender, RoutedEventArgs e)
        {
            if (!Underline)
            {
                textBox.TextDecorations = TextDecorations.Underline;
                Underline = true;
            }
            else
            {
                textBox.TextDecorations = null;
                Underline = false;
            }
        }

        private void RadioButton_Checked_Black(object sender, RoutedEventArgs e)
        {
            RadioButton textBlack = (RadioButton)sender;
            Border textColor = textBlack.Content as Border;
            if (textBox != null)
            {
                if (textColor != null)
                {
                    textColor.Background = Brushes.Black;
                }
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_Red(object sender, RoutedEventArgs e)
        {
            RadioButton textBlack = (RadioButton)sender;
            Border textColor = textBlack.Content as Border;
            if (textBox != null)
            {
                if (textColor != null)
                {
                    textColor.Background = Brushes.Red;
                }
                textBox.Foreground = Brushes.Red;
            }
        }
    }
}