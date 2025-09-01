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
        private bool _novoNumero = false;
        private string _operacao;
        private int _contador;

        public MainWindow()
        {
            InitializeComponent();
        }

       private void LimparVisor()
       {
            txtVisor.Text = "";
        }

        private bool UltimoDigitoEOperador()
        {
            char ultimo = txtVisor.Text[txtVisor.Text.Length - 1];

            if(ultimo == '+' || ultimo == '-' || ultimo == 'x' || ultimo == '/')
            {
                return true;
            }
            return false;
        }

        private void FinalizarNumeroUm()
        {
            Calculadora.N1 = Convert.ToDouble(txtVisor.Text);
        }

        private void FinalizarNumeroDois()
        {
            Calculadora.N2 = Convert.ToDouble(txtVisor.Text);
            double resultado = Calculadora.Calcular(Calculadora.N1, Calculadora.N2, _operacao);
            txtVisor.Text = resultado.ToString();
            Calculadora.N1 = resultado;
            txtHistorico.Text = "";
            _novoNumero = true;
        }

        private void ENovoNumero()
        {
            if (_novoNumero)
            {
                LimparVisor();
                _novoNumero = false;
            }
        }

        private void IniciaComZeroOuOperador()
        {
            if (txtVisor.Text == "0") // Se o visor estiver vazio ou contiver um operador, limpa o visor e adicioanr no historico
            {
                LimparVisor();
            }
            else if (!int.TryParse(txtVisor.Text.ToString(), out _))
            {
                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
            }
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            LimparVisor();
            _contador = 0;
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
            IniciaComZeroOuOperador();
            ENovoNumero(); 
            txtVisor.Text += btnSete.Content.ToString(); // Adiciona o número 7 ao visor
        }

        private void btnOito_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnOito.Content.ToString(); // Adiciona o número 8 ao visor
        }

        private void btnNove_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnNove.Content.ToString(); // Adiciona o número 9 ao visor
        }

        private void btnQuatro_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnQuatro.Content.ToString();
        }

        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnCinco.Content.ToString();
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnSeis.Content.ToString();
        }

        private void btnUm_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnUm.Content.ToString();
        }

        private void btnDois_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnDois.Content.ToString();
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnTres.Content.ToString();
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            IniciaComZeroOuOperador();
            ENovoNumero();
            txtVisor.Text += btnZero.Content.ToString();
        }

        private void btnMais_Click(object sender, RoutedEventArgs e)
        {
            if(UltimoDigitoEOperador()) return; // Impede que aconteça a duplicação de operações

            if(!_novoNumero) //Quando limpo o visor, eu torno falso, como o calculo do N2 chama
            {
                _contador++;
                if (_contador > 1) // Caso clique mais de uma vez, já calcula para iniciar outro cálculo
                {
                    FinalizarNumeroDois();
                }
                else
                {
                    FinalizarNumeroUm();
                }
            }
            txtVisor.Text += " " + btnMais.Content.ToString();
            _operacao = btnMais.Content.ToString();
            _novoNumero = true;
        }

        private void btnMenos_Click(object sender, RoutedEventArgs e)
        {
            if (UltimoDigitoEOperador()) return;

            if (!_novoNumero) //Quando limpo o visor, eu torno falso, como o calculo do N2 chama
            {
                _contador++;
                if (_contador > 1) // Caso clique mais de uma vez, já calcula para iniciar outro cálculo
                {
                    FinalizarNumeroDois();
                }
                else
                {
                    FinalizarNumeroUm();
                }
            }
            txtVisor.Text += " " + btnMenos.Content.ToString();
            _operacao = "-";
            _novoNumero = true;
        }

        private void btnMultiplica_Click(object sender, RoutedEventArgs e)
        {
            if (UltimoDigitoEOperador()) return;

            if (!_novoNumero) //Quando limpo o visor, eu torno falso, como o calculo do N2 chama
            {
                _contador++;
                if (_contador > 1) // Caso clique mais de uma vez, já calcula para iniciar outro cálculo
                {
                    FinalizarNumeroDois();
                }
                else
                {
                    FinalizarNumeroUm();
                }
            }
            txtVisor.Text += " " + btnMultiplica.Content.ToString();
            _operacao = btnMultiplica.Content.ToString(); 
            _novoNumero = true;
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            if (UltimoDigitoEOperador()) return;

            if (!_novoNumero) //Quando limpo o visor, eu torno falso, como o calculo do N2 chama
            {
                _contador++;
                if (_contador > 1) // Caso clique mais de uma vez, já calcula para iniciar outro cálculo
                {
                    FinalizarNumeroDois();
                }
                else
                {
                    FinalizarNumeroUm();
                }
            }
            txtVisor.Text += " " + btnDividir.Content.ToString();
            _operacao = btnDividir.Content.ToString();
            _novoNumero = true;
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroDois();
            _contador = 0;
        }
    }
}
