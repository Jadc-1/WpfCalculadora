using System;
using System.Collections.Generic;
using System.Globalization;
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
        private bool _primeiroNumero = true;
        private bool _novoNumero = false;
        private bool _decimal = false;
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

            if (ultimo == '+' || ultimo == '-' || ultimo == 'x' || ultimo == '/' || ultimo == '%' || ultimo == '½' || ultimo == '=')
            {
                return true;
            }
            return false;
        }


        private void FinalizarNumeroUm()
        {
            if(_decimal)
            {
                decimal numeroDecimal = decimal.Parse(txtVisor.Text, new CultureInfo("pt-BR")); // Aceita vírgula como separador decimal
                _decimal = false;
            }
            
            if(decimal.TryParse(txtVisor.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out decimal numero)) // Verifica se o valor no visor é um número decimal
            {
                txtVisor.Text = numero.ToString(); // Atualiza o visor com o número formatado corretamente
                Calculadora.N1 = Convert.ToDouble(txtVisor.Text);
            }
            Calculadora.N1 = Convert.ToDouble(txtVisor.Text);
        }

        private void FinalizarNumeroDois()
        {

            if (_decimal)
            {
                decimal numeroDecimal = decimal.Parse(txtVisor.Text, new CultureInfo("pt-BR")); // Aceita vírgula como separador decimal
                _decimal = false;
            }

            _primeiroNumero = false; // Indica que o primeiro número já foi inserido, assim o botão CE limpa o N2 ao invés do N1.
            Calculadora.N2 = Convert.ToDouble(txtVisor.Text);
             
            if (Calculadora.N2 == 0 && (_operacao == "/" || _operacao == "%")) // Evita que o N2 seja zero, para não dar erro na subtração, dois parenteses seguindo a idea das portas logicas E e OU (lembra da abertura paralela para seguir dois caminhos)
            {
                double tamanhoFonte = 25;
                txtVisor.Text = "Não é possível dividir por zero";
                txtVisor.FontSize = tamanhoFonte;
                _novoNumero = true;
                return;
            }
            
            double resultado = Calculadora.Calcular(Calculadora.N1, Calculadora.N2, _operacao);
            txtVisor.Text = resultado.ToString();
            Calculadora.N1 = resultado; // Adiciono o resultado ao N1 para que possa continuar calculando, pois o contador continua a contar, e o N2 será atualizado
            txtHistorico.Text = "";
            _novoNumero = true; // Indica que o próximo número é novo, para limpar o visor depois de calcular
        }

        private void ENovoNumero()
        {
            double tamanhoFonte = 35;
            txtVisor.FontSize = tamanhoFonte; // Restaura o tamanho da fonte para o padrão (Por conta da verificação fração)
            txtHistorico.FontSize = 15;
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
            else if (!int.TryParse(txtVisor.Text.ToString(), out _)) // Se o visor não for um número (ou seja, é um operador), limpa o visor e adiciona no histórico
            {

                txtHistorico.Text = Calculadora.N1.ToString() + $" {_operacao}";
                if(txtHistorico.Text.StartsWith($"0 {_operacao}")) // Para caso seja valor decimal, não enviar um zero para o historico
                {
                    txtHistorico.Text = txtHistorico.Text.Remove(0, 2); // Remove o "0 " do início do histórico
                }

                if (txtHistorico.Text.Length > 4)
                {
                    txtHistorico.FontSize = 10;
                }
                else if (txtHistorico.Text.Length > 8)
                {
                    txtHistorico.FontSize = 8;
                }
            }
        }


        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            LimparVisor();
            txtHistorico.FontSize = 15;
            _contador = 0;
            Calculadora.N1 = 0;
            Calculadora.N2 = 0;
            _operacao = "";
            txtVisor.Text = "0";
            txtHistorico.Text = "";
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
            if (txtVisor.Text == "")
            {
                txtVisor.Text = "0";
            }
            _novoNumero = false; // Indica que o próximo número não é novo, para não limpar o visor depois de deletar
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

            if(!_novoNumero) //Quando limpo o visor, eu torno falso um novo número, entrando na condição, caso seja o primeiro contador finaliza o N1, caso entre novamente já finaliza o N2
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

        private void btnPorcent_Click(object sender, RoutedEventArgs e)
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
            txtVisor.Text += " " + btnPorcent.Content.ToString();
            _operacao = btnPorcent.Content.ToString();
            _novoNumero = true; //Limpa o visor para quando a pessoa digitar um novo número (Todo número digitado tem o método ENovoNumero chamado, que limpa o visor)
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            txtHistorico.FontSize = 15;
            if (_primeiroNumero) // Se ainda estiver no primeiro número, limpa o N1
            {
                LimparVisor();
                txtVisor.Text = "0";
                Calculadora.N1 = 0;
                _operacao = "";
            }
            else // Se já estiver no segundo número, limpa o N2
            {
                LimparVisor();
                txtVisor.Text = "0";
                Calculadora.N2 = 0;
            }
        }

        private void btnFracao_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            if (Calculadora.N1 == 0)
            {
                double tamanhoFonte = 25;
                txtVisor.Text = "Não é possível dividir por zero";
                txtVisor.FontSize = tamanhoFonte;
                _novoNumero = true;
                return;
            }
            _novoNumero = true;
            var fracaoResultado = Calculadora.Fracao();
            txtHistorico.Text = $"1/({Calculadora.N1})";
            txtVisor.Text = fracaoResultado.ToString();
        }

        private void btnPotencia_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            var potenciaResultado = Calculadora.Potencia();
            _novoNumero = true;
            txtHistorico.Text = $"sqr({Calculadora.N1})";
            txtVisor.Text = potenciaResultado.ToString();
        }

        private void btnRaiz_Click(object sender, RoutedEventArgs e)
        {
            FinalizarNumeroUm();
            var raizResultado = Calculadora.RaizQuadrada();
            _novoNumero = true;
            txtHistorico.Text = $"√({Calculadora.N1})";
            txtVisor.Text = raizResultado.ToString();
            Calculadora.N1 = raizResultado; // Permite continuar calculando a partir do resultado da raiz
        }

        private void btnMaisOuMenos_Click(object sender, RoutedEventArgs e)
        {
            if (txtVisor.Text == "0" || txtVisor.Text == "") return; // Impede que o botão mais ou menos funcione se o visor estiver vazio ou com zero
            double N1 = Convert.ToDouble(txtVisor.Text);
            if (N1 > 0)
            {
                N1 *= -1;
                txtVisor.Text = N1.ToString();
            }
            else if(N1 < 0)
            {
                N1 *= -1;
                txtVisor.Text = N1.ToString();
            }
        }

        private void btnVirgula_Click(object sender, RoutedEventArgs e)
        {
            if(txtVisor.Text.Contains(",")) return; // Impede que a vírgula seja adicionada mais de uma vez
            _decimal = true;
            if(_decimal)
            {
                txtVisor.Text += ",";
            }

        }

    }
}
