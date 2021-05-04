using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculator
{
	public partial class MainPage : ContentPage
	{
        char operador = ' ';    // Last Math Operator Used
        string prevValue = "0"; // Previos Value or Number

        public MainPage()
		{
			InitializeComponent();
		}

        public void addNumber(object sender, EventArgs e)
        {
            var numbButton = (Button)sender;
            if ((numero.Text.Contains("0")) && (numero.Text.Length == 1))
                numero.Text = numbButton.Text;
            else
                if (numero.Text.Length < 10)
                numero.Text += numbButton.Text;

        }

        public void clearNumber(object sender, EventArgs e)
        {
            numero.Text = "0";
            prevValue = "0";
            operador = ' ';

        }

        public void operatorClick(object sender, EventArgs e)
        {
            var opBtn = (Button)sender; //Captura el boton presionado
            var op = opBtn.Text; //verificar el Texto del boton presionado
            switch (op)
            {
                case ".":
                    if (!numero.Text.Contains("."))
                        numero.Text += ".";
                    break;
                case "+/-":
                    numero.Text = (Convert.ToDouble(numero.Text) * -1).ToString();                 break;
                case "%":
                    numero.Text = (Convert.ToDouble(numero.Text) / 100).ToString();
                    break;
                case "+":
                    prevValue = numero.Text;
                    numero.Text = "0";
                    operador = '+';
                    break;
                case "-":
                    prevValue = numero.Text;
                    numero.Text = "0";
                    operador = '-';
                    break;
                case "X":
                    prevValue = numero.Text;
                    numero.Text = "0";
                    operador = 'X';
                    break;

                case "=":
                    double val1 = Convert.ToDouble(prevValue);
                    double val2 = Convert.ToDouble(numero.Text);
                    switch (operador)
                    {
                        case '+':
                            numero.Text = (val1 + val2).ToString();
                            break;
                        case '-':
                            numero.Text = (val1 - val2).ToString();
                            break;
                        case 'X':
                            numero.Text = (val1 * val2).ToString();
                            break;
                        case '/':
                            numero.Text = (val1 / val2).ToString();
                            break;
                        case '%':
                            numero.Text = (val1 *( val2 * .01 )).ToString();
                            break;
                    }
                    break;
            }

        }
    }
}
