using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class MyCalculator
    {

        MainWindow mainwindow;

        Operand leftOperand = null;
        Operand rightOperand = null;
        string cachedOperator;
        double result;

        public MyCalculator(MainWindow mainwindow)
        {
            this.mainwindow = mainwindow;
        }

        public void Calculate(double operand, string @operator)
        {
            if(leftOperand == null)
            {
                leftOperand = new Operand { value = operand };
                cachedOperator = @operator;
            }
            else if(rightOperand == null)
            {
                rightOperand = new Operand { value = operand };
                SetResult(cachedOperator);
                leftOperand.value = result;
                rightOperand = null;

                if (@operator == "=")
                {
                    leftOperand = null;
                    mainwindow.subscreen.Content = result;
                }
                else
                {
                    cachedOperator = @operator;
                }

            }
        }

        public void SetResult(string @operator)
        {
            switch (@operator)
            {
                case "/":
                    try
                    {
                        result = leftOperand.value / rightOperand.value;
                        mainwindow.mainscreen.Content = result;
                    }
                    catch (Exception)
                    {
                        mainwindow.subscreen.Content = "Teilen durch 0 ist nicht erlaubt";
                    }
                    break;
                case "*":
                    result = leftOperand.value * rightOperand.value;
                    mainwindow.mainscreen.Content = result;
                    break;
                case "-":
                    result = leftOperand.value - rightOperand.value;
                    mainwindow.mainscreen.Content = result;
                    break;
                case "+":
                    result = leftOperand.value + rightOperand.value;
                    mainwindow.mainscreen.Content = result;
                    break;
            }
        }

        public void Clear()
        {
            leftOperand = null;
            rightOperand = null;
            mainwindow.mainscreen.Content = "";
            mainwindow.subscreen.Content = "";
        }

    }
}
