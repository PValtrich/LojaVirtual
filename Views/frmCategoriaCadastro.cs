using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmCategoriaCadastro : Form
    {
        //Criar instância da controller
        CategoriaController categoriaController = new CategoriaController();

        //Parâmetros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar
        //O valor padrão é 1, pois se não for passado nada via parâmetro
        //a tela abre no modo cadastro. O objeto é recebido via parâmetro
        //para ser preenchido em tela.
        public frmCategoriaCadastro(int Acao = 1, Categoria categoria = null)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Se o objeto estiver nulo só podemos abrir no modo cadastro
            if (categoria == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(categoria);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Categoria";
                }
                else
                    this.Text = "Alterar Categoria";
            }
        }

        void DesativarCampos()
        {
            txtNomeCategoria.ReadOnly = true;
            txtDescricao.ReadOnly = true;
            txtDepartamento.ReadOnly = true;
            txtLocalizacao.ReadOnly = true;
            dtpDataCadastro.Enabled = false;
            txtResponsavel.ReadOnly = true;
            txtOrdem.ReadOnly = true;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Categoria categoria)
        {
            //Mapeamos o objeto com os campos em tela
            txtId.Text = categoria.CategoriaId.ToString();
            txtNomeCategoria.Text = categoria.NomeCategoria;
            txtDescricao.Text = categoria.Descricao;
            txtDepartamento.Text = categoria.Departamento;
            txtLocalizacao.Text = categoria.Localizacao;
            dtpDataCadastro.Value = categoria.DataCadastro;
            txtResponsavel.Text = categoria.Responsavel;
            txtOrdem.Text = categoria.Ordem.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Se o botão salvar estiver oculto, a tela está no modo visualização
            //portanto podemos dar o result e fechar a tela
            if (btnSalvar.Visible == false)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //Validar se a tela poderá ser fechada
                if (MessageBox.Show(
                    "Deseja realmente sair?" + Environment.NewLine + Environment.NewLine +
                    "Ao sair os dados alterados serão descartados!",
                    "Confirmação!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        //Valida os campos antes de salvar. Retorna false se algo estiver incorreto
        bool ValidarCampos()
        {
            if (txtNomeCategoria.Text == "")
            {
                MessageBox.Show("Informe o campo \"Nome da categoria\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeCategoria.Focus();
                return false;
            }

            int valorOrdem;
            if (!int.TryParse(txtOrdem.Text, out valorOrdem) || valorOrdem < 0)
            {
                MessageBox.Show("O campo \"Ordem de exibição\" deve ser um número válido, maior ou igual a zero.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrdem.Focus();
                return false;
            }

            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Primeiro validamos os campos preenchidos
            if (!ValidarCampos())
                return;

            //Instanciamos o objeto e mapeamos as informações com ele
            //OBS: não mapeamos o campo ID agora, pois a tabela é IDENTITY
            Categoria categoria = new Categoria();
            categoria.NomeCategoria = txtNomeCategoria.Text;
            categoria.Descricao = txtDescricao.Text;
            categoria.Departamento = txtDepartamento.Text;
            categoria.Localizacao = txtLocalizacao.Text;
            categoria.DataCadastro = dtpDataCadastro.Value;
            categoria.Responsavel = txtResponsavel.Text;
            categoria.Ordem = int.Parse(txtOrdem.Text);

            //Se o campo ID estiver vazio estamos no modo cadastro,
            //senão estamos no modo alteração
            int retorno = 0;
            try
            {
                if (txtId.Text == "")
                    retorno = categoriaController.Inserir(categoria);
                else
                {
                    //Nesse momento precisamos mapear o ID ao objeto
                    categoria.CategoriaId = int.Parse(txtId.Text);
                    retorno = categoriaController.Alterar(categoria);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Falha ao salvar o cadastro!" + Environment.NewLine + Environment.NewLine +
                    ex.Message,
                    "Atenção!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (retorno > 0)
            {
                MessageBox.Show(
                    "Cadastro salvo com sucesso!",
                    "Informação!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(
                    "Falha ao salvar o cadastro!",
                    "Atenção!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }
    }
}
