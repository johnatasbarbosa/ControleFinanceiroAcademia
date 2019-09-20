namespace ControleAcademia
{
    partial class ConfirmacaoPagamento
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtAluno = new System.Windows.Forms.TextBox();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.labelAluno = new System.Windows.Forms.Label();
            this.labelMes = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(119, 213);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtAluno
            // 
            this.txtAluno.Location = new System.Drawing.Point(87, 83);
            this.txtAluno.Name = "txtAluno";
            this.txtAluno.Size = new System.Drawing.Size(199, 20);
            this.txtAluno.TabIndex = 1;
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(87, 126);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(124, 20);
            this.txtMes.TabIndex = 2;
            // 
            // labelAluno
            // 
            this.labelAluno.AutoSize = true;
            this.labelAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAluno.Location = new System.Drawing.Point(16, 81);
            this.labelAluno.Name = "labelAluno";
            this.labelAluno.Size = new System.Drawing.Size(50, 20);
            this.labelAluno.TabIndex = 3;
            this.labelAluno.Text = "Aluno";
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMes.Location = new System.Drawing.Point(16, 126);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(39, 20);
            this.labelMes.TabIndex = 4;
            this.labelMes.Text = "Mês";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(16, 174);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(140, 20);
            this.labelData.TabIndex = 5;
            this.labelData.Text = "Dia do pagamento";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(29, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(257, 29);
            this.labelTitulo.TabIndex = 7;
            this.labelTitulo.Text = "Confirmar pagamento?";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(162, 176);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(68, 20);
            this.txtData.TabIndex = 58;
            this.txtData.ValidatingType = typeof(System.DateTime);
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValor.Location = new System.Drawing.Point(119, 38);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(49, 29);
            this.labelValor.TabIndex = 59;
            this.labelValor.Text = "R$ ";
            // 
            // ConfirmacaoPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 249);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.labelAluno);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.txtAluno);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "ConfirmacaoPagamento";
            this.Text = "ConfirmacaoPagamento";
            this.Load += new System.EventHandler(this.ConfirmacaoPagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtAluno;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label labelAluno;
        private System.Windows.Forms.Label labelMes;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label labelValor;
    }
}