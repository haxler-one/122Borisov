using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace PracticalWork1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            shRadioButton.IsChecked = true;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            double x = double.Parse(xTextBox.Text);
            double y = double.Parse(yTextBox.Text);
            double result = CalculateFunction(x, y);
            resultTextBox.Text = result.ToString();

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            xTextBox.Clear();
            yTextBox.Clear();
            resultTextBox.Clear();
        }

        private bool ValidateInput()
        {
            double x, y;

            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
            {
                MessageBox.Show("Заполните все поля ввода!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!double.TryParse(xTextBox.Text, out x))
            {
                MessageBox.Show("Некорректный формат числа в поле x!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!double.TryParse(yTextBox.Text, out y))
            {
                MessageBox.Show("Некорректный формат числа в поле y!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private double CalculateFunction(double x, double y)
        {
            double fx = 0;

            if (shRadioButton.IsChecked == true)
            {
                fx = Math.Sinh(x);
            }
            else if (x2RadioButton.IsChecked == true)
            {
                fx = Math.Pow(x, 2);
            }
            else if (exRadioButton.IsChecked == true)
            {
                fx = Math.Exp(x);
            }

            double result;
            if (x - y == 0)
            {
                result = Math.Pow(fx, 2) + Math.Pow(y, 2) + Math.Sin(y);
            }
            else if (x - y > 0)
            {
                result = Math.Pow((fx - y), 2) + Math.Cos(y);
            }
            else
            {
                result = Math.Pow((y - fx), 2) + Math.Tan(y);
            }
            return result;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
    }
}