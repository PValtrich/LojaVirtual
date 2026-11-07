namespace LojaVirtual.Views
{
    partial class frmCategoriaCadastro
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
            this.lblNomeCategoria = new System.Windows.Forms.Label();
            this.txtNomeCategoria = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.lblOrdem = new System.Windows.Forms.Label();
            this.txtOrdem = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            // lblNomeCategoria
            //
            this.lblNomeCategoria.AutoSize = true;
            this.lblNomeCategoria.Location = new System.Drawing.Point(89, 12);
            this.lblNomeCategoria.Name = "lblNomeCategoria";
            this.lblNomeCategoria.Size = new System.Drawing.Size(111, 13);
            this.lblNomeCategoria.Text = "Nome da categoria:";
            this.lblNomeCategoria.TabIndex = 2;
            //
            // txtNomeCategoria
            //
            this.txtNomeCategoria.Location = new System.Drawing.Point(89, 28);
            this.txtNomeCategoria.MaxLength = 50;
            this.txtNomeCategoria.Name = "txtNomeCategoria";
            this.txtNomeCategoria.Size = new System.Drawing.Size(419, 20);
            this.txtNomeCategoria.TabIndex = 3;
            //
            // lblDescricao
            //
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(62, 13);
            this.lblDescricao.Text = "Descrição:";
            this.lblDescricao.TabIndex = 4;
            //
            // txtDescricao
            //
            this.txtDescricao.Location = new System.Drawing.Point(12, 76);
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(496, 20);
            this.txtDescricao.TabIndex = 5;
            //
            // lblDepartamento
            //
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(12, 108);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(80, 13);
            this.lblDepartamento.Text = "Departamento:";
            this.lblDepartamento.TabIndex = 6;
            //
            // txtDepartamento
            //
            this.txtDepartamento.Location = new System.Drawing.Point(12, 124);
            this.txtDepartamento.MaxLength = 50;
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(242, 20);
            this.txtDepartamento.TabIndex = 7;
            //
            // lblLocalizacao
            //
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new System.Drawing.Point(266, 108);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(74, 13);
            this.lblLocalizacao.Text = "Localização:";
            this.lblLocalizacao.TabIndex = 8;
            //
            // txtLocalizacao
            //
            this.txtLocalizacao.Location = new System.Drawing.Point(266, 124);
            this.txtLocalizacao.MaxLength = 50;
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(242, 20);
            this.txtLocalizacao.TabIndex = 9;
            //
            // lblResponsavel
            //
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(12, 156);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(74, 13);
            this.lblResponsavel.Text = "Responsável:";
            this.lblResponsavel.TabIndex = 10;
            //
            // txtResponsavel
            //
            this.txtResponsavel.Location = new System.Drawing.Point(12, 172);
            this.txtResponsavel.MaxLength = 100;
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(340, 20);
            this.txtResponsavel.TabIndex = 11;
            //
            // lblDataCadastro
            //
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Location = new System.Drawing.Point(364, 156);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(105, 13);
            this.lblDataCadastro.Text = "Data de cadastro:";
            this.lblDataCadastro.TabIndex = 12;
            //
            // dtpDataCadastro
            //
            this.dtpDataCadastro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCadastro.Location = new System.Drawing.Point(364, 172);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(144, 20);
            this.dtpDataCadastro.TabIndex = 13;
            //
            // lblOrdem
            //
            this.lblOrdem.AutoSize = true;
            this.lblOrdem.Location = new System.Drawing.Point(12, 204);
            this.lblOrdem.Name = "lblOrdem";
            this.lblOrdem.Size = new System.Drawing.Size(115, 13);
            this.lblOrdem.Text = "Ordem de exibição:";
            this.lblOrdem.TabIndex = 14;
            //
            // txtOrdem
            //
            this.txtOrdem.Location = new System.Drawing.Point(12, 220);
            this.txtOrdem.MaxLength = 6;
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(100, 20);
            this.txtOrdem.TabIndex = 15;
            this.txtOrdem.Text = "0";
            //
            // btnSalvar
            //
            this.btnSalvar.Location = new System.Drawing.Point(352, 256);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.TabIndex = 16;
            //
            // btnCancelar
            //
            this.btnCancelar.Location = new System.Drawing.Point(433, 256);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.TabIndex = 17;
            //
            // frmCategoriaCadastro
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 291);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblNomeCategoria);
            this.Controls.Add(this.txtNomeCategoria);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.lblDataCadastro);
            this.Controls.Add(this.dtpDataCadastro);
            this.Controls.Add(this.lblOrdem);
            this.Controls.Add(this.txtOrdem);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCategoriaCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNomeCategoria;
        private System.Windows.Forms.TextBox txtNomeCategoria;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        private System.Windows.Forms.Label lblOrdem;
        private System.Windows.Forms.TextBox txtOrdem;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
