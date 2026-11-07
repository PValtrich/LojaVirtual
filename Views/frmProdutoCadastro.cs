using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmProdutoCadastro : Form
    {
        //Criar instância da controller
        ProdutoController produtoController = new ProdutoController();

        //Atributos que armazenam os registros selecionados pelo usuário
        Categoria categoriaProduto;

        //Parâmetros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar
        //O valor padrão é 1, pois se não for passado nada via parâmetro
        //a tela abre no modo cadastro. O objeto é recebido via parâmetro
        //para ser preenchido em tela.
        public frmProdutoCadastro(int Acao = 1, Produto produto = null)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Se o objeto estiver nulo só podemos abrir no modo cadastro
            if (produto == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(produto);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Produto";
                }
                else
                    this.Text = "Alterar Produto";
            }
        }

        void DesativarCampos()
        {
            txtNomeProduto.ReadOnly = true;
            txtDescricao.ReadOnly = true;
            txtPreco.ReadOnly = true;
            txtEstoque.ReadOnly = true;
            txtMarca.ReadOnly = true;
            btnPesquisarCategoria.Enabled = false;
            txtPeso.ReadOnly = true;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Produto produto)
        {
            //Mapeamos o objeto com os campos em tela
            txtId.Text = produto.ProdutoId.ToString();
            txtNomeProduto.Text = produto.NomeProduto;
            txtDescricao.Text = produto.Descricao;
            txtPreco.Text = produto.Preco.ToString();
            txtEstoque.Text = produto.Estoque.ToString();
            txtMarca.Text = produto.Marca;
            categoriaProduto = produto.Categoria;
            txtCategoriaNome.Text = categoriaProduto.NomeCategoria;
            txtPeso.Text = produto.Peso.ToString();
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
            if (txtNomeProduto.Text == "")
            {
                MessageBox.Show("Informe o campo \"Nome do produto\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeProduto.Focus();
                return false;
            }

            decimal valorPreco;
            if (!decimal.TryParse(txtPreco.Text, out valorPreco) || valorPreco < 0)
            {
                MessageBox.Show("O campo \"Preço\" deve ser um número válido, maior ou igual a zero.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return false;
            }

            int valorEstoque;
            if (!int.TryParse(txtEstoque.Text, out valorEstoque) || valorEstoque < 0)
            {
                MessageBox.Show("O campo \"Estoque\" deve ser um número válido, maior ou igual a zero.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstoque.Focus();
                return false;
            }

            if (categoriaProduto == null)
            {
                MessageBox.Show("Selecione o campo \"Categoria\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPesquisarCategoria.Focus();
                return false;
            }

            decimal valorPeso;
            if (txtPeso.Text != "" && (!decimal.TryParse(txtPeso.Text, out valorPeso) || valorPeso < 0))
            {
                MessageBox.Show("O campo \"Peso (kg)\" deve ser um número válido, maior ou igual a zero.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeso.Focus();
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
            Produto produto = new Produto();
            produto.NomeProduto = txtNomeProduto.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Preco = decimal.Parse(txtPreco.Text);
            produto.Estoque = int.Parse(txtEstoque.Text);
            produto.Marca = txtMarca.Text;
            produto.Categoria = categoriaProduto;
            if (txtPeso.Text == "")
                produto.Peso = 0;
            else
                produto.Peso = decimal.Parse(txtPeso.Text);

            //Se o campo ID estiver vazio estamos no modo cadastro,
            //senão estamos no modo alteração
            int retorno = 0;
            try
            {
                if (txtId.Text == "")
                    retorno = produtoController.Inserir(produto);
                else
                {
                    //Nesse momento precisamos mapear o ID ao objeto
                    produto.ProdutoId = int.Parse(txtId.Text);
                    retorno = produtoController.Alterar(produto);
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

        private void btnPesquisarCategoria_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção exibindo o botão "Selecionar"
            frmCategoriaSelecao frm = new frmCategoriaSelecao(true);
            //Se o resultado for OK, o usuário clicou em "Selecionar"
            if (frm.ShowDialog() == DialogResult.OK)
            {
                categoriaProduto = frm.categoriaSelecao;
                txtCategoriaNome.Text = categoriaProduto.NomeCategoria;
            }
        }
    }
}
