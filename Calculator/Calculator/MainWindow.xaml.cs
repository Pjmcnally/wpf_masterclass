using System;
using System.Collections.Generic;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: Convert this to decimal after testing
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            buttonAC.Click += ButtonAC_Click;
            buttonNegative.Click += ButtonNegative_Click;
            buttonPercent.Click += ButtonPercent_Click;
            buttonEqual.Click += ButtonEqual_Click;
        }

        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mul(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastNumber, newNumber);
                        break;
                }
            }

            resultLabel.Content = result.ToString();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = (lastNumber / 100).ToString();
            }
        }

        private void ButtonNegative_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = (lastNumber * -1).ToString();
            }
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == buttonAdd)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == buttonSubtract)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            else if (sender == buttonMultiply)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == buttonDivide)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as Button).Content.ToString();
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = number;
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{number}";
            }
        }

        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing - Only one decimal point allowed
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Sub(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double Div(double num1, double num2)
        {
            if (num2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return num1 / num2;
        }
    }
}
