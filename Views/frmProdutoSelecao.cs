using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmProdutoSelecao : Form
    {
        //Criar instância da controller
        ProdutoController produtoController = new ProdutoController();

        //Atributo público necessário para retornar o registro
        //selecionado quando o usuário clicar no botão "Selecionar".
        public Produto produtoSelecao;

        //O parâmetro "ExibirBotaoSelecionar" define se o botão
        //"Selecionar" deve ser exibido. O valor padrão é "false".
        public frmProdutoSelecao(bool ExibirBotaoSelecionar = false)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Evita que a grade crie as colunas de forma automática.
            //As colunas foram definidas na tela (DataPropertyName).
            dgvRegistros.AutoGenerateColumns = false;

            btnSelecionar.Visible = ExibirBotaoSelecionar;
        }

        private void frmProdutoSelecao_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        //Método para realizar a pesquisa no banco de dados
        void AtualizarGrid()
        {
            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = produtoController.GetByNome(txtFiltro.Text);
            //Atualizo a contagem de registros com a quantidade de itens na grade
            lblRegistros.Text = "Registros encontrados: " + dgvRegistros.RowCount.ToString();
        }

        Produto GetProduto()
        {
            //Valido se possui registros selecionados
            if (dgvRegistros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum registro selecionado.", "Informação!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
                //Converto o item da grade em objeto e retorno
                return (dgvRegistros.SelectedRows[0].DataBoundItem as Produto);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Chamo a tela de cadastro no modo cadastro (padrão)
            //e, se o retorno for OK, atualizo a grade
            frmProdutoCadastro frm = new frmProdutoCadastro();
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Produto selecionado = GetProduto();
            if (selecionado == null)
                return;

            //Chamo a tela de cadastro no modo alteração (2)
            frmProdutoCadastro frm = new frmProdutoCadastro(2, selecionado);
            if (frm.ShowDialog() == DialogResult.OK)
                AtualizarGrid();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Produto selecionado = GetProduto();
            if (selecionado == null)
                return;

            //Chamo a tela de cadastro no modo visualização (3)
            frmProdutoCadastro frm = new frmProdutoCadastro(3, selecionado);
            frm.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Produto selecionado = GetProduto();
            if (selecionado == null)
                return;

            //Confirmação para exclusão do registro
            if (MessageBox.Show(
                    "Deseja realmente excluir o registro?",
                    "Confirmação!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    if (produtoController.Excluir(selecionado.ProdutoId) > 0)
                    {
                        MessageBox.Show(
                            "Cadastro excluído com sucesso!",
                            "Informação!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        AtualizarGrid();
                    }
                    else
                        MessageBox.Show(
                            "Falha ao excluir o cadastro!",
                            "Atenção!", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    //Acontece quando o registro está vinculado a outros cadastros
                    MessageBox.Show(
                        "Não foi possível excluir o cadastro!" + Environment.NewLine + Environment.NewLine +
                        "Ele pode estar sendo utilizado em outro cadastro." + Environment.NewLine + Environment.NewLine +
                        ex.Message,
                        "Atenção!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void Selecionar()
        {
            produtoSelecao = GetProduto();
            if (produtoSelecao != null)
                this.DialogResult = DialogResult.OK;
        }
    }
}
