namespace LojaVirtual.Views
{
    partial class frmPedidoSelecao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cbxFiltro = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dgvRegistros = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.colPedidoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClienteNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuarioNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataPedidoTratada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotalTratado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(12, 8);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(117, 13);
            this.lblFiltro.Text = "Forma de pagamento:";
            this.lblFiltro.TabIndex = 0;
            // 
            // cbxFiltro
            // 
            this.cbxFiltro.FormattingEnabled = true;
            this.cbxFiltro.Items.AddRange(new object[] {
            "Todas",
            "Dinheiro",
            "Cartão de Crédito",
            "Cartão de Débito",
            "Pix",
            "Boleto"});
            this.cbxFiltro.Location = new System.Drawing.Point(12, 24);
            this.cbxFiltro.Name = "cbxFiltro";
            this.cbxFiltro.Size = new System.Drawing.Size(250, 21);
            this.cbxFiltro.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(673, 22);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.TabIndex = 2;
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AllowUserToAddRows = false;
            this.dgvRegistros.AllowUserToDeleteRows = false;
            this.dgvRegistros.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPedidoId,
            this.colClienteNome,
            this.colUsuarioNome,
            this.colDataPedidoTratada,
            this.colValorTotalTratado,
            this.colFormaPagamento});
            this.dgvRegistros.MultiSelect = false;
            this.dgvRegistros.Location = new System.Drawing.Point(12, 61);
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RowHeadersVisible = false;
            this.dgvRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistros.Size = new System.Drawing.Size(736, 220);
            this.dgvRegistros.TabIndex = 3;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(12, 290);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(148, 13);
            this.lblRegistros.Text = "Registros encontrados: 0";
            this.lblRegistros.TabIndex = 4;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(12, 315);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Visible = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            this.btnSelecionar.TabIndex = 5;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(430, 315);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnAdicionar.TabIndex = 6;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(511, 315);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.TabIndex = 7;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(592, 315);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.TabIndex = 8;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(673, 315);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            this.btnVisualizar.TabIndex = 9;
            // 
            // colPedidoId
            // 
            this.colPedidoId.DataPropertyName = "PedidoId";
            this.colPedidoId.HeaderText = "Código";
            this.colPedidoId.Name = "colPedidoId";
            this.colPedidoId.ReadOnly = true;
            this.colPedidoId.Width = 60;
            // 
            // colClienteNome
            // 
            this.colClienteNome.DataPropertyName = "ClienteNome";
            this.colClienteNome.HeaderText = "Cliente";
            this.colClienteNome.Name = "colClienteNome";
            this.colClienteNome.ReadOnly = true;
            this.colClienteNome.Width = 190;
            // 
            // colUsuarioNome
            // 
            this.colUsuarioNome.DataPropertyName = "UsuarioNome";
            this.colUsuarioNome.HeaderText = "Atendente";
            this.colUsuarioNome.Name = "colUsuarioNome";
            this.colUsuarioNome.ReadOnly = true;
            this.colUsuarioNome.Width = 140;
            // 
            // colDataPedidoTratada
            // 
            this.colDataPedidoTratada.DataPropertyName = "DataPedidoTratada";
            this.colDataPedidoTratada.HeaderText = "Data";
            this.colDataPedidoTratada.Name = "colDataPedidoTratada";
            this.colDataPedidoTratada.ReadOnly = true;
            this.colDataPedidoTratada.Width = 80;
            // 
            // colValorTotalTratado
            // 
            this.colValorTotalTratado.DataPropertyName = "ValorTotalTratado";
            this.colValorTotalTratado.HeaderText = "Valor Total";
            this.colValorTotalTratado.Name = "colValorTotalTratado";
            this.colValorTotalTratado.ReadOnly = true;
            this.colValorTotalTratado.Width = 100;
            // 
            // colFormaPagamento
            // 
            this.colFormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormaPagamento.DataPropertyName = "FormaPagamento";
            this.colFormaPagamento.HeaderText = "Pagamento";
            this.colFormaPagamento.Name = "colFormaPagamento";
            this.colFormaPagamento.ReadOnly = true;
            // 
            // frmPedidoSelecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 350);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cbxFiltro);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgvRegistros);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVisualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPedidoSelecao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleção de Pedidos";
            this.Load += new System.EventHandler(this.frmPedidoSelecao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cbxFiltro;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dgvRegistros;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuarioNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataPedidoTratada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotalTratado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPagamento;
    }
}
