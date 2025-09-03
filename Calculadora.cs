using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCalculadora
{
    public class Calculadora
    {
        public double N1 { get; private set; }
        public double N2 { get; private set; }

        public Calculadora(double n1, double n2)
        {
            this.N1 = n1;
            this.N2 = n2;
        }


        public double Calcular(double n1, double n2, string operacao)
        {
            switch(operacao)
            {
                case "+":
                    return Somar();
                case "-":
                    return Subtrair();
                case "x":
                    return Multiplicar();
                case "/":
                    return Dividir();
                case "%":
                    return Modulo();
                default:
                    MessageBox.Show("Operação inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            return 0;
        }

        private double Somar() { return N1 + N2; }

        private double Subtrair() { return N1 - N2; }

        private double Multiplicar() { return N1 * N2; }

        private double Dividir() { return N1 / N2;  }

        private double Modulo() { return N1 % N2; }

        public double Fracao() { return 1 / N1; }

        public double Potencia() { return Math.Pow(N1, 2); }

        public double RaizQuadrada() { return Math.Sqrt(N1); }


    }
}
