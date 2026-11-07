namespace LojaVirtual.Views
{
    partial class frmPedidoCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuarioNome = new System.Windows.Forms.TextBox();
            this.btnPesquisarUsuario = new System.Windows.Forms.Button();
            this.lblDataPedido = new System.Windows.Forms.Label();
            this.dtpDataPedido = new System.Windows.Forms.DateTimePicker();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cbxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblEnderecoEntrega = new System.Windows.Forms.Label();
            this.txtEnderecoEntrega = new System.Windows.Forms.TextBox();
            this.lblCidadeEntrega = new System.Windows.Forms.Label();
            this.txtCidadeEntrega = new System.Windows.Forms.TextBox();
            this.lblItens = new System.Windows.Forms.Label();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.colItemProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            //
            // lblId
            //
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 12);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(43, 13);
            this.lblId.Text = "Código:";
            this.lblId.TabIndex = 0;
            //
            // txtId
            //
            this.txtId.Location = new System.Drawing.Point(12, 28);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(65, 20);
            this.txtId.TabIndex = 1;
            //
            // lblCliente
            //
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(89, 12);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(49, 13);
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.TabIndex = 2;
            //
            // txtClienteNome
            //
            this.txtClienteNome.Location = new System.Drawing.Point(89, 28);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(339, 20);
            this.txtClienteNome.TabIndex = 3;
            //
            // btnPesquisarCliente
            //
            this.btnPesquisarCliente.Location = new System.Drawing.Point(433, 27);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarCliente.Text = "Pesquisar";
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            this.btnPesquisarCliente.TabIndex = 4;
            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 60);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(124, 13);
            this.lblUsuario.Text = "Atendente (usuário):";
            this.lblUsuario.TabIndex = 5;
            //
            // txtUsuarioNome
            //
            this.txtUsuarioNome.Location = new System.Drawing.Point(12, 76);
            this.txtUsuarioNome.Name = "txtUsuarioNome";
            this.txtUsuarioNome.ReadOnly = true;
            this.txtUsuarioNome.Size = new System.Drawing.Size(416, 20);
            this.txtUsuarioNome.TabIndex = 6;
            //
            // btnPesquisarUsuario
            //
            this.btnPesquisarUsuario.Location = new System.Drawing.Point(433, 75);
            this.btnPesquisarUsuario.Name = "btnPesquisarUsuario";
            this.btnPesquisarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarUsuario.Text = "Pesquisar";
            this.btnPesquisarUsuario.UseVisualStyleBackColor = true;
            this.btnPesquisarUsuario.Click += new System.EventHandler(this.btnPesquisarUsuario_Click);
            this.btnPesquisarUsuario.TabIndex = 7;
            //
            // lblDataPedido
            //
            this.lblDataPedido.AutoSize = true;
            this.lblDataPedido.Location = new System.Drawing.Point(12, 108);
            this.lblDataPedido.Name = "lblDataPedido";
            this.lblDataPedido.Size = new System.Drawing.Size(93, 13);
            this.lblDataPedido.Text = "Data do pedido:";
            this.lblDataPedido.TabIndex = 8;
            //
            // dtpDataPedido
            //
            this.dtpDataPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPedido.Location = new System.Drawing.Point(12, 124);
            this.dtpDataPedido.Name = "dtpDataPedido";
            this.dtpDataPedido.Size = new System.Drawing.Size(150, 20);
            this.dtpDataPedido.TabIndex = 9;
            //
            // lblValorTotal
            //
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(174, 108);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(74, 13);
            this.lblValorTotal.Text = "Valor total:";
            this.lblValorTotal.TabIndex = 10;
            //
            // txtValorTotal
            //
            this.txtValorTotal.Location = new System.Drawing.Point(174, 124);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(150, 20);
            this.txtValorTotal.TabIndex = 11;
            //
            // lblFormaPagamento
            //
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(336, 108);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(117, 13);
            this.lblFormaPagamento.Text = "Forma de pagamento:";
            this.lblFormaPagamento.TabIndex = 12;
            //
            // cbxFormaPagamento
            //
            this.cbxFormaPagamento.FormattingEnabled = true;
            this.cbxFormaPagamento.Items.AddRange(new object[] {
            "Dinheiro",
            "Cartão de Crédito",
            "Cartão de Débito",
            "Pix",
            "Boleto"});
            this.cbxFormaPagamento.Location = new System.Drawing.Point(336, 124);
            this.cbxFormaPagamento.Name = "cbxFormaPagamento";
            this.cbxFormaPagamento.Size = new System.Drawing.Size(172, 21);
            this.cbxFormaPagamento.TabIndex = 13;
            //
            // lblEnderecoEntrega
            //
            this.lblEnderecoEntrega.AutoSize = true;
            this.lblEnderecoEntrega.Location = new System.Drawing.Point(12, 156);
            this.lblEnderecoEntrega.Name = "lblEnderecoEntrega";
            this.lblEnderecoEntrega.Size = new System.Drawing.Size(124, 13);
            this.lblEnderecoEntrega.Text = "Endereço de entrega:";
            this.lblEnderecoEntrega.TabIndex = 14;
            //
            // txtEnderecoEntrega
            //
            this.txtEnderecoEntrega.Location = new System.Drawing.Point(12, 172);
            this.txtEnderecoEntrega.MaxLength = 150;
            this.txtEnderecoEntrega.Name = "txtEnderecoEntrega";
            this.txtEnderecoEntrega.Size = new System.Drawing.Size(300, 20);
            this.txtEnderecoEntrega.TabIndex = 15;
            //
            // lblCidadeEntrega
            //
            this.lblCidadeEntrega.AutoSize = true;
            this.lblCidadeEntrega.Location = new System.Drawing.Point(324, 156);
            this.lblCidadeEntrega.Name = "lblCidadeEntrega";
            this.lblCidadeEntrega.Size = new System.Drawing.Size(111, 13);
            this.lblCidadeEntrega.Text = "Cidade de entrega:";
            this.lblCidadeEntrega.TabIndex = 16;
            //
            // txtCidadeEntrega
            //
            this.txtCidadeEntrega.Location = new System.Drawing.Point(324, 172);
            this.txtCidadeEntrega.MaxLength = 60;
            this.txtCidadeEntrega.Name = "txtCidadeEntrega";
            this.txtCidadeEntrega.Size = new System.Drawing.Size(184, 20);
            this.txtCidadeEntrega.TabIndex = 17;
            //
            // lblItens
            //
            this.lblItens.AutoSize = true;
            this.lblItens.Location = new System.Drawing.Point(12, 204);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(92, 13);
            this.lblItens.Text = "Itens do pedido:";
            this.lblItens.TabIndex = 18;
            //
            // dgvItens
            //
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.AllowUserToResizeRows = false;
            this.dgvItens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemProduto,
            this.colItemQuantidade,
            this.colItemPreco,
            this.colItemSubtotal});
            this.dgvItens.Location = new System.Drawing.Point(12, 220);
            this.dgvItens.MultiSelect = false;
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.RowHeadersVisible = false;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(496, 130);
            this.dgvItens.TabIndex = 19;
            //
            // colItemProduto
            //
            this.colItemProduto.DataPropertyName = "ProdutoNome";
            this.colItemProduto.HeaderText = "Produto";
            this.colItemProduto.Name = "colItemProduto";
            this.colItemProduto.ReadOnly = true;
            //
            // colItemQuantidade
            //
            this.colItemQuantidade.DataPropertyName = "Quantidade";
            this.colItemQuantidade.HeaderText = "Quantidade";
            this.colItemQuantidade.Name = "colItemQuantidade";
            this.colItemQuantidade.ReadOnly = true;
            //
            // colItemPreco
            //
            this.colItemPreco.DataPropertyName = "PrecoUnitarioTratado";
            this.colItemPreco.HeaderText = "Preço unitário";
            this.colItemPreco.Name = "colItemPreco";
            this.colItemPreco.ReadOnly = true;
            //
            // colItemSubtotal
            //
            this.colItemSubtotal.DataPropertyName = "SubtotalTratado";
            this.colItemSubtotal.HeaderText = "Subtotal";
            this.colItemSubtotal.Name = "colItemSubtotal";
            this.colItemSubtotal.ReadOnly = true;
            //
            // lblQuantidade
            //
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(12, 362);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(61, 13);
            this.lblQuantidade.Text = "Quantidade:";
            this.lblQuantidade.TabIndex = 20;
            //
            // nudQuantidade
            //
            this.nudQuantidade.Location = new System.Drawing.Point(12, 378);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(80, 20);
            this.nudQuantidade.TabIndex = 21;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnAdicionarItem
            //
            this.btnAdicionarItem.Location = new System.Drawing.Point(100, 376);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(120, 23);
            this.btnAdicionarItem.Text = "Adicionar item";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            this.btnAdicionarItem.TabIndex = 22;
            //
            // btnRemoverItem
            //
            this.btnRemoverItem.Location = new System.Drawing.Point(226, 376);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(120, 23);
            this.btnRemoverItem.Text = "Remover item";
            this.btnRemoverItem.UseVisualStyleBackColor = true;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
            this.btnRemoverItem.TabIndex = 23;
            //
            // btnSalvar
            //
            this.btnSalvar.Location = new System.Drawing.Point(352, 410);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.TabIndex = 24;
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(433, 410);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.TabIndex = 25;
            //
            // frmPedidoCadastro
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 445);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtClienteNome);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuarioNome);
            this.Controls.Add(this.btnPesquisarUsuario);
            this.Controls.Add(this.lblDataPedido);
            this.Controls.Add(this.dtpDataPedido);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.cbxFormaPagamento);
            this.Controls.Add(this.lblEnderecoEntrega);
            this.Controls.Add(this.txtEnderecoEntrega);
            this.Controls.Add(this.lblCidadeEntrega);
            this.Controls.Add(this.txtCidadeEntrega);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.dgvItens);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.btnRemoverItem);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPedidoCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Pedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Button btnPesquisarCliente;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuarioNome;
        private System.Windows.Forms.Button btnPesquisarUsuario;
        private System.Windows.Forms.Label lblDataPedido;
        private System.Windows.Forms.DateTimePicker dtpDataPedido;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cbxFormaPagamento;
        private System.Windows.Forms.Label lblEnderecoEntrega;
        private System.Windows.Forms.TextBox txtEnderecoEntrega;
        private System.Windows.Forms.Label lblCidadeEntrega;
        private System.Windows.Forms.TextBox txtCidadeEntrega;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemSubtotal;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
