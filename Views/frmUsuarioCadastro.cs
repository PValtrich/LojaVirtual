using LojaVirtual.Controllers;
using LojaVirtual.Models;
using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmUsuarioCadastro : Form
    {
        //Criar instância da controller
        UsuarioController usuarioController = new UsuarioController();

        //Parâmetros para definir a ação
        //1 = Cadastrar
        //2 = Alterar
        //3 = Visualizar
        //O valor padrão é 1, pois se não for passado nada via parâmetro
        //a tela abre no modo cadastro. O objeto é recebido via parâmetro
        //para ser preenchido em tela.
        public frmUsuarioCadastro(int Acao = 1, Usuario usuario = null)
        {
            InitializeComponent();
            Estilo.AplicarComCabecalho(this);

            //Se o objeto estiver nulo só podemos abrir no modo cadastro
            if (usuario == null)
                Acao = 1;

            if (Acao != 1)
            {
                CarregarDados(usuario);

                if (Acao == 3)
                {
                    DesativarCampos();
                    this.Text = "Visualizar Usuário";
                }
                else
                    this.Text = "Alterar Usuário";
            }
        }

        void DesativarCampos()
        {
            txtNome.ReadOnly = true;
            txtCpf.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtSenha.ReadOnly = true;
            cbxPerfil.Enabled = false;
            txtTelefone.ReadOnly = true;
            dtpDataCadastro.Enabled = false;

            btnSalvar.Visible = false;
            btnCancelar.Text = "OK";
        }

        void CarregarDados(Usuario usuario)
        {
            //Mapeamos o objeto com os campos em tela
            txtId.Text = usuario.UsuarioId.ToString();
            txtNome.Text = usuario.Nome;
            txtCpf.Text = usuario.Cpf;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;
            cbxPerfil.Text = usuario.Perfil;
            txtTelefone.Text = usuario.Telefone;
            dtpDataCadastro.Value = usuario.DataCadastro;
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

            if (txtSenha.Text == "")
            {
                MessageBox.Show("Informe o campo \"Senha\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            if (cbxPerfil.Text == "")
            {
                MessageBox.Show("Informe o campo \"Perfil\".", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxPerfil.Focus();
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
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Cpf = txtCpf.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Perfil = cbxPerfil.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.DataCadastro = dtpDataCadastro.Value;

            //Se o campo ID estiver vazio estamos no modo cadastro,
            //senão estamos no modo alteração
            int retorno = 0;
            try
            {
                if (txtId.Text == "")
                    retorno = usuarioController.Inserir(usuario);
                else
                {
                    //Nesse momento precisamos mapear o ID ao objeto
                    usuario.UsuarioId = int.Parse(txtId.Text);
                    retorno = usuarioController.Alterar(usuario);
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
