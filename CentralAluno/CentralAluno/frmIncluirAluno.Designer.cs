
namespace CentralAluno.Desktop
{
    partial class frmIncluirAluno
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDadosAluno = new System.Windows.Forms.GroupBox();
            this.btnIncluirAluno = new System.Windows.Forms.Button();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblRG = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.grpDadosAluno.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDadosAluno
            // 
            this.grpDadosAluno.Controls.Add(this.btnIncluirAluno);
            this.grpDadosAluno.Controls.Add(this.txtCPF);
            this.grpDadosAluno.Controls.Add(this.txtRG);
            this.grpDadosAluno.Controls.Add(this.txtNome);
            this.grpDadosAluno.Controls.Add(this.lblCPF);
            this.grpDadosAluno.Controls.Add(this.lblRG);
            this.grpDadosAluno.Controls.Add(this.lblNome);
            this.grpDadosAluno.Location = new System.Drawing.Point(25, 65);
            this.grpDadosAluno.Name = "grpDadosAluno";
            this.grpDadosAluno.Size = new System.Drawing.Size(379, 313);
            this.grpDadosAluno.TabIndex = 0;
            this.grpDadosAluno.TabStop = false;
            this.grpDadosAluno.Text = "Dados dos Aluno";
            // 
            // btnIncluirAluno
            // 
            this.btnIncluirAluno.Location = new System.Drawing.Point(10, 136);
            this.btnIncluirAluno.Name = "btnIncluirAluno";
            this.btnIncluirAluno.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirAluno.TabIndex = 6;
            this.btnIncluirAluno.Text = "Incluir Aluno";
            this.btnIncluirAluno.UseVisualStyleBackColor = true;
            this.btnIncluirAluno.Click += new System.EventHandler(this.btnIncluirAluno_Click);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(63, 95);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 5;
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(63, 65);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(100, 20);
            this.txtRG.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(63, 31);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 3;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(7, 102);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 2;
            this.lblCPF.Text = "CPF:";
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Location = new System.Drawing.Point(6, 68);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(26, 13);
            this.lblRG.TabIndex = 1;
            this.lblRG.Text = "RG:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(7, 34);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // frmIncluirAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpDadosAluno);
            this.Name = "frmIncluirAluno";
            this.Text = "Form1";
            this.grpDadosAluno.ResumeLayout(false);
            this.grpDadosAluno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosAluno;
        private System.Windows.Forms.Button btnIncluirAluno;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.Label lblNome;
    }
}

