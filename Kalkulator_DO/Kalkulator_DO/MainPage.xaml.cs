using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kalkulator_DO
{
    public enum Operation
    {
        None,
        Add,
        Substract,
        Multiply,
        Divide,
        Square,
        SquareRoot,
        Inverse
    }
    public partial class MainPage : ContentPage
    {
        private double a = 0;
        private double b = 0;
        private Operation operation = Operation.None;
        private bool comma = false;
        private double result = 0;
        private bool equalsClicked = false;
        private double width = 0; 
        private double height = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void Print()
        {
            if (operation == Operation.None)
            {
                Output.Text = a.ToString();
                OutputEquation.Text = "";
                return;
            }
            switch (operation)
            {
                case Operation.Add:
                case Operation.Substract:
                case Operation.Multiply:
                case Operation.Divide:
                    if (equalsClicked)
                    {
                        Output.Text = result.ToString();
                        OutputEquation.Text = a.ToString() + " " + OperationToSign(operation) + " " + b.ToString() + " =";
                    }
                    else
                    {
                        Output.Text = b.ToString();
                        OutputEquation.Text = a.ToString() + " " + OperationToSign(operation);
                    }
                    break;
                case Operation.Square:
                    Output.Text = result.ToString();
                    OutputEquation.Text = "sqr(" + a + ")";
                    break;
                case Operation.SquareRoot:
                    Output.Text = result.ToString();
                    OutputEquation.Text = "sqrt(" + a + ")";
                    break;
                case Operation.Inverse:
                    Output.Text = result.ToString();
                    OutputEquation.Text = "1/" + a.ToString();
                    break;
            }
        }
        private string OperationToSign(Operation operation)
        {
            string operationSign = "";
            switch (operation)
            {
                case Operation.Add:
                    operationSign = "+";
                    break;
                case Operation.Substract:
                    operationSign = "-";
                    break;
                case Operation.Multiply:
                    operationSign = "*";
                    break;
                case Operation.Divide:
                    operationSign = "/";
                    break;
            }
            return operationSign;
        }
        private void Operation_Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "+":
                    operation = Operation.Add;
                    break;
                case "-":
                    operation = Operation.Substract;
                    break;
                case "*":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Divide;
                    break;
                case "x^2":
                    result = a * a;
                    operation = Operation.Square;
                    Print();
                    break;
                case "sqrt":
                    result = Math.Sqrt(a);
                    operation = Operation.SquareRoot;
                    Print();
                    break;
                case "1/x":
                    result = 1 / a;
                    operation = Operation.Inverse;
                    Print();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void number_Clicked(object sender, EventArgs e)
        {
            if (operation == Operation.None)
            {
                if (comma)
                {
                    a = double.Parse(a.ToString() + "." + ((Button)sender).Text);
                    comma = false;
                }
                else
                    a = double.Parse(a.ToString() + ((Button)sender).Text);
            }
            else
            {
                if (comma)
                {
                    b = double.Parse(b.ToString() + "." + ((Button)sender).Text);
                    comma = false;
                }
                else
                    b = double.Parse(b.ToString() + ((Button)sender).Text);
            }
        }

        private void Comma_Clicked(object sender, EventArgs e)
        {
            comma = true;
        }

        private void Equals_Clicked(object sender, EventArgs e)
        {
            switch (operation)
            {
                case Operation.Add:
                    result = a + b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Substract:
                    result = a - b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Multiply:
                    result = a * b;
                    equalsClicked = true;
                    Print();
                    break;
                case Operation.Divide:
                    result = a / b;
                    equalsClicked = true;
                    Print();
                    break;
            }
        }
    }
}
