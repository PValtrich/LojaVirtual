using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmPedidoCadastro : Form
    {
        //Criar instância da controller
        PedidoController pedidoController = new PedidoController();

        //Atributos que armazenam os registros selecionados pelo usuário
        Cliente clientePedido;
        Usuario usuarioPedido;

        //Parâmetros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar
        //O valor padrão é 1, pois se não for passado nada via parâmetro
        //a tela abre no modo cadastro. O objeto é recebido via parâmetro
        //para ser preenchido em tela.
        public frmPedidoCadastro(int Acao = 1, Pedido pedido = null)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Se o objeto estiver nulo só podemos abrir no modo cadastro
            if (pedido == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(pedido);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Pedido";
                }
                else
                    this.Text = "Alterar Pedido";
            }
        }

        void DesativarCampos()
        {
            btnPesquisarCliente.Enabled = false;
            btnPesquisarUsuario.Enabled = false;
            dtpDataPedido.Enabled = false;
            txtValorTotal.ReadOnly = true;
            cbxFormaPagamento.Enabled = false;
            txtEnderecoEntrega.ReadOnly = true;
            txtCidadeEntrega.ReadOnly = true;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Pedido pedido)
        {
            //Mapeamos o objeto com os campos em tela
            txtId.Text = pedido.PedidoId.ToString();
            clientePedido = pedido.Cliente;
            txtClienteNome.Text = clientePedido.Nome;
            usuarioPedido = pedido.Usuario;
            txtUsuarioNome.Text = usuarioPedido.Nome;
            dtpDataPedido.Value = pedido.DataPedido;
            txtValorTotal.Text = pedido.ValorTotal.ToString();
            cbxFormaPagamento.Text = pedido.FormaPagamento;
            txtEnderecoEntrega.Text = pedido.EnderecoEntrega;
            txtCidadeEntrega.Text = pedido.CidadeEntrega;
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
            if (clientePedido == null)
            {
                MessageBox.Show("Selecione o campo \"Cliente\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPesquisarCliente.Focus();
                return false;
            }

            if (usuarioPedido == null)
            {
                MessageBox.Show("Selecione o campo \"Atendente\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPesquisarUsuario.Focus();
                return false;
            }

            decimal valorTotal;
            if (!decimal.TryParse(txtValorTotal.Text, out valorTotal) || valorTotal < 0)
            {
                MessageBox.Show("O campo \"Valor total\" deve ser um número válido, maior ou igual a zero.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                return false;
            }

            if (cbxFormaPagamento.Text == "")
            {
                MessageBox.Show("Informe o campo \"Forma de pagamento\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxFormaPagamento.Focus();
                return false;
            }

            if (txtEnderecoEntrega.Text == "")
            {
                MessageBox.Show("Informe o campo \"Endereço de entrega\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEnderecoEntrega.Focus();
                return false;
            }

            if (txtCidadeEntrega.Text == "")
            {
                MessageBox.Show("Informe o campo \"Cidade de entrega\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCidadeEntrega.Focus();
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
            Pedido pedido = new Pedido();
            pedido.Cliente = clientePedido;
            pedido.Usuario = usuarioPedido;
            pedido.DataPedido = dtpDataPedido.Value;
            pedido.ValorTotal = decimal.Parse(txtValorTotal.Text);
            pedido.FormaPagamento = cbxFormaPagamento.Text;
            pedido.EnderecoEntrega = txtEnderecoEntrega.Text;
            pedido.CidadeEntrega = txtCidadeEntrega.Text;

            //Se o campo ID estiver vazio estamos no modo cadastro,
            //senão estamos no modo alteração
            int retorno = 0;
            try
            {
                if (txtId.Text == "")
                    retorno = pedidoController.Inserir(pedido);
                else
                {
                    //Nesse momento precisamos mapear o ID ao objeto
                    pedido.PedidoId = int.Parse(txtId.Text);
                    retorno = pedidoController.Alterar(pedido);
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

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção exibindo o botão "Selecionar"
            frmClienteSelecao frm = new frmClienteSelecao(true);
            //Se o resultado for OK, o usuário clicou em "Selecionar"
            if (frm.ShowDialog() == DialogResult.OK)
            {
                clientePedido = frm.clienteSelecao;
                txtClienteNome.Text = clientePedido.Nome;
                if (txtEnderecoEntrega.Text == "")
                    txtEnderecoEntrega.Text = clientePedido.Endereco;
                if (txtCidadeEntrega.Text == "")
                    txtCidadeEntrega.Text = clientePedido.Cidade;
            }
        }

        private void btnPesquisarUsuario_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção exibindo o botão "Selecionar"
            frmUsuarioSelecao frm = new frmUsuarioSelecao(true);
            //Se o resultado for OK, o usuário clicou em "Selecionar"
            if (frm.ShowDialog() == DialogResult.OK)
            {
                usuarioPedido = frm.usuarioSelecao;
                txtUsuarioNome.Text = usuarioPedido.Nome;
            }
        }
    }
}
