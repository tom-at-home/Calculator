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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MyCalculator calculator;
        bool clearMainscreen = false;
        bool clearSubscreen = false;

        public MainWindow()
        {
            InitializeComponent();
            this.calculator = new MyCalculator(this);
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button currBtn = (Button)sender;
            string currVal = Convert.ToString(currBtn.Content);
            if (clearMainscreen)
            {
                mainscreen.Content = "";
            }
            if (clearSubscreen)
            {
                subscreen.Content = "";
            }
            mainscreen.Content += currVal;
            subscreen.Content += currVal;
            clearMainscreen = false;
            clearSubscreen = false;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button currBtn = (Button)sender;
            double operand = Convert.ToDouble(mainscreen.Content);
            string @operator = Convert.ToString(currBtn.Content);
            if(@operator != "=")
            {
                subscreen.Content += " " + @operator + " ";
            }
            clearMainscreen = true;
            calculator.Calculate(operand, @operator);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            calculator.Clear();
        }
    }
}
