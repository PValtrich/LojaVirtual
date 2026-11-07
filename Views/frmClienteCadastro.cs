using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmClienteCadastro : Form
    {
        //Criar instância da controller
        ClienteController clienteController = new ClienteController();

        //Parâmetros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar
        //O valor padrão é 1, pois se não for passado nada via parâmetro
        //a tela abre no modo cadastro. O objeto é recebido via parâmetro
        //para ser preenchido em tela.
        public frmClienteCadastro(int Acao = 1, Cliente cliente = null)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Se o objeto estiver nulo só podemos abrir no modo cadastro
            if (cliente == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(cliente);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Cliente";
                }
                else
                    this.Text = "Alterar Cliente";
            }
        }

        void DesativarCampos()
        {
            txtNome.ReadOnly = true;
            txtCpf.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTelefone.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtCidade.ReadOnly = true;
            dtpDataCadastro.Enabled = false;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Cliente cliente)
        {
            //Mapeamos o objeto com os campos em tela
            txtId.Text = cliente.ClienteId.ToString();
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtEndereco.Text = cliente.Endereco;
            txtCidade.Text = cliente.Cidade;
            dtpDataCadastro.Value = cliente.DataCadastro;
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
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o campo \"Nome\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (txtCpf.Text == "")
            {
                MessageBox.Show("Informe o campo \"CPF\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return false;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Informe o campo \"E-mail\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informe o campo \"Telefone\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefone.Focus();
                return false;
            }

            if (txtEndereco.Text == "")
            {
                MessageBox.Show("Informe o campo \"Endereço\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndereco.Focus();
                return false;
            }

            if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe o campo \"Cidade\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCidade.Focus();
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
            Cliente cliente = new Cliente();
            cliente.Nome = txtNome.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.DataCadastro = dtpDataCadastro.Value;

            //Se o campo ID estiver vazio estamos no modo cadastro,
            //senão estamos no modo alteração
            int retorno = 0;
            try
            {
                if (txtId.Text == "")
                    retorno = clienteController.Inserir(cliente);
                else
                {
                    //Nesse momento precisamos mapear o ID ao objeto
                    cliente.ClienteId = int.Parse(txtId.Text);
                    retorno = clienteController.Alterar(cliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Falha ao salvar o cadastro!" + Environment.NewLine + Environment.NewLine +
                    "Verifique se o CPF ou e-mail já está cadastrado." + Environment.NewLine + Environment.NewLine +
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
