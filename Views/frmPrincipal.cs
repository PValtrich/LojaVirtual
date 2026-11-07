using System;
using System.Windows.Forms;

namespace LojaVirtual.Views
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            Estilo.Aplicar(this);
            lblTitulo.ForeColor = System.Drawing.Color.White;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção do cadastro
            frmClienteSelecao frm = new frmClienteSelecao();
            frm.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção do cadastro
            frmUsuarioSelecao frm = new frmUsuarioSelecao();
            frm.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção do cadastro
            frmCategoriaSelecao frm = new frmCategoriaSelecao();
            frm.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção do cadastro
            frmProdutoSelecao frm = new frmProdutoSelecao();
            frm.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abro a tela de seleção do cadastro
            frmPedidoSelecao frm = new frmPedidoSelecao();
            frm.ShowDialog();
        }

        //Os botões grandes da tela principal abrem as mesmas telas do menu
        private void btnClientes_Click(object sender, EventArgs e)
        {
            clientesToolStripMenuItem_Click(sender, e);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            usuariosToolStripMenuItem_Click(sender, e);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            categoriasToolStripMenuItem_Click(sender, e);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            produtosToolStripMenuItem_Click(sender, e);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            pedidosToolStripMenuItem_Click(sender, e);
        }
    }
}
