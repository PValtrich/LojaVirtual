using System;
using System.Drawing;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    //Define o visual das telas (cores e fontes) em um só lugar.
    //Cada tela chama Estilo.Aplicar(this) ou Estilo.AplicarComCabecalho(this)
    //depois do InitializeComponent.
    internal static class Estilo
    {
        //Cores de um e-commerce: amarelo, azul escuro e cinza claro
        public static readonly Color Amarelo = Color.FromArgb(255, 221, 0);
        public static readonly Color Azul = Color.FromArgb(38, 42, 110);
        public static readonly Color Fundo = Color.FromArgb(243, 244, 247);
        public static readonly Color Texto = Color.FromArgb(40, 40, 50);
        public static readonly Color Vermelho = Color.FromArgb(200, 40, 40);
        public static readonly Color Cinza = Color.FromArgb(205, 207, 214);

        const int AlturaCabecalho = 56;

        //Aplica as cores e fontes na tela e em todos os controles dela
        public static void Aplicar(Form tela)
        {
            tela.BackColor = Fundo;
            tela.Font = new Font("Segoe UI", 9F);
            AplicarControles(tela.Controls);
        }

        //Aplica o visual, alinha os rótulos e coloca uma faixa azul com o título no topo
        public static void AplicarComCabecalho(Form tela)
        {
            Aplicar(tela);
            AlinharRotulos(tela);

            //Empurra os controles para baixo para caber a faixa do título
            foreach (Control controle in tela.Controls)
                controle.Top += AlturaCabecalho;
            tela.ClientSize = new Size(tela.ClientSize.Width, tela.ClientSize.Height + AlturaCabecalho);

            Label cabecalho = new Label();
            cabecalho.Name = "lblCabecalho";
            cabecalho.Text = tela.Text;
            cabecalho.Dock = DockStyle.Top;
            cabecalho.Height = AlturaCabecalho;
            cabecalho.BackColor = Azul;
            cabecalho.ForeColor = Amarelo;
            cabecalho.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cabecalho.Padding = new Padding(20, 0, 0, 0);
            cabecalho.TextAlign = ContentAlignment.MiddleLeft;
            tela.Controls.Add(cabecalho);

            //Quando o título da tela mudar (ex.: Visualizar ou Alterar), a faixa acompanha
            tela.TextChanged += new EventHandler(AtualizarCabecalho);
        }

        static void AtualizarCabecalho(object sender, EventArgs e)
        {
            Form tela = (Form)sender;
            tela.Controls["lblCabecalho"].Text = tela.Text;
        }

        //Cada rótulo fica logo acima do campo que descreve e com a mesma borda esquerda
        static void AlinharRotulos(Form tela)
        {
            foreach (Control rotulo in tela.Controls)
            {
                if (!(rotulo is Label))
                    continue;

                Control campo = null;
                int menorDistancia = int.MaxValue;
                foreach (Control candidato in tela.Controls)
                {
                    if (!(candidato is TextBox || candidato is ComboBox || candidato is DateTimePicker))
                        continue;

                    int distancia = candidato.Top - rotulo.Bottom;
                    if (distancia < 0 || distancia > 30 || Math.Abs(candidato.Left - rotulo.Left) > 30)
                        continue;

                    if (distancia < menorDistancia)
                    {
                        menorDistancia = distancia;
                        campo = candidato;
                    }
                }

                if (campo != null)
                {
                    rotulo.Left = campo.Left;
                    rotulo.Top = campo.Top - rotulo.Height - 2;
                }
            }
        }

        static void AplicarControles(Control.ControlCollection controles)
        {
            foreach (Control controle in controles)
            {
                if (controle is Button)
                    EstilizarBotao((Button)controle);
                else if (controle is DataGridView)
                    EstilizarGrade((DataGridView)controle);
                else if (controle is MenuStrip)
                    EstilizarMenu((MenuStrip)controle);
                else if (controle is TextBox || controle is ComboBox || controle is DateTimePicker)
                {
                    controle.BackColor = Color.White;
                    controle.ForeColor = Texto;
                }
                else if (controle is Label)
                    controle.ForeColor = Texto;

                AplicarControles(controle.Controls);
            }
        }

        //Hierarquia dos botões: ação principal em amarelo, ações secundárias em branco,
        //excluir em vermelho e cancelar em cinza
        static void EstilizarBotao(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.Cursor = Cursors.Hand;
            botao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            botao.FlatAppearance.BorderColor = Cinza;
            botao.FlatAppearance.BorderSize = 1;

            if (botao.Text == "Excluir")
            {
                botao.BackColor = Vermelho;
                botao.ForeColor = Color.White;
                botao.FlatAppearance.BorderColor = Vermelho;
            }
            else if (botao.Text == "Cancelar" || botao.Text == "OK")
            {
                botao.BackColor = Cinza;
                botao.ForeColor = Texto;
            }
            else if (botao.Text == "Salvar" || botao.Text == "Adicionar" || botao.Text == "Pesquisar" || botao.Text == "Selecionar")
            {
                botao.BackColor = Amarelo;
                botao.ForeColor = Texto;
                botao.FlatAppearance.BorderColor = Amarelo;
            }
            else if (botao.Parent is Panel)
            {
                //Botões grandes da tela principal
                botao.BackColor = Color.White;
                botao.ForeColor = Azul;
                botao.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                botao.FlatAppearance.BorderColor = Amarelo;
                botao.FlatAppearance.BorderSize = 2;
            }
            else
            {
                botao.BackColor = Color.White;
                botao.ForeColor = Azul;
            }
        }

        static void EstilizarGrade(DataGridView grade)
        {
            grade.BackgroundColor = Fundo;
            grade.BorderStyle = BorderStyle.None;
            grade.GridColor = Cinza;
            grade.EnableHeadersVisualStyles = false;
            grade.RowHeadersVisible = false;
            grade.ColumnHeadersHeight = 32;
            grade.ColumnHeadersDefaultCellStyle.BackColor = Azul;
            grade.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grade.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grade.DefaultCellStyle.BackColor = Color.White;
            grade.DefaultCellStyle.ForeColor = Texto;
            grade.DefaultCellStyle.SelectionBackColor = Amarelo;
            grade.DefaultCellStyle.SelectionForeColor = Texto;
            grade.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 251);
        }

        static void EstilizarMenu(MenuStrip menu)
        {
            menu.BackColor = Amarelo;
            menu.ForeColor = Texto;
            menu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
    }
}
