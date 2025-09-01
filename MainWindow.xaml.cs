using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfCalculadora
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        Calculadora Calculadora = new Calculadora(0, 0);
        private string _operacao;

        public MainWindow()
        {
            InitializeComponent();
        }

       private void LimparVisor()
       {
            //if (N2 == 0)
            //{
            //    MessageBox.Show("Divisão por zero não é permitida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return 0;
            //}
            txtVisor.Text = "";
       }

        private void FinalizarNumeroUm()
        {
            Calculadora.N1 = Convert.ToDouble(txtVisor.Text);
        }

        private void FinalizarNumeroDois()
        {
            Calculadora.N2 = Convert.ToDouble(txtVisor);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            LimparVisor();
            txtVisor.Text = "0";
            txtHistorico.Text = "";
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            if(txtVisor.Text == "")
            {
                txtVisor.Text = "0";
            }
        }

        private void btnSete_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnSete.Content.ToString(); // Adiciona o número 7 ao visor
        }

        private void btnOito_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnOito.Content.ToString(); // Adiciona o número 8 ao visor
        }

        private void btnNove_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnNove.Content.ToString(); // Adiciona o número 9 ao visor
        }

        private void btnQuatro_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnQuatro.Content.ToString();
        }

        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnCinco.Content.ToString();
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnSeis.Content.ToString();
        }

        private void btnUm_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnUm.Content.ToString();
        }

        private void btnDois_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnDois.Content.ToString();
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnTres.Content.ToString();
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
            txtVisor.Text += btnZero.Content.ToString();
        }

        private void btnMais_Click(object sender, RoutedEventArgs e)
        {
            int contador = 0;
            contador++;
            if (contador > 1)
            {
                FinalizarNumeroDois();
            }
            FinalizarNumeroUm();
            txtVisor.Text += " " + btnMais.Content.ToString() + " ";
            _operacao = btnMais.Content.ToString();
        }

        private void btnMenos_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            txtVisor.Text += " " + btnMenos.Content.ToString() + " ";
            _operacao = btnMenos.Content.ToString();
        }

        private void btnMultiplica_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            txtVisor.Text += " " + btnMultiplica.Content.ToString() + " ";
            _operacao = btnMultiplica.Content.ToString();
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            txtVisor.Text += " " + btnDividir.Content.ToString() + " ";
            _operacao = btnDividir.Content.ToString();
        }
    }
}
