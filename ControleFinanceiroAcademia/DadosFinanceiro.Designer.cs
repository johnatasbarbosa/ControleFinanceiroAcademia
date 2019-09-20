namespace ControleAcademia
{
    partial class DadosFinanceiro
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblPrevisto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArrecadado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Mês = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Previsto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrecadado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 25);
            this.label6.TabIndex = 45;
            this.label6.Text = "Dados Financeiros";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mês,
            this.Previsto,
            this.Arrecadado});
            this.dgvDados.Location = new System.Drawing.Point(12, 171);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.Size = new System.Drawing.Size(413, 155);
            this.dgvDados.TabIndex = 50;
            // 
            // lblPrevisto
            // 
            this.lblPrevisto.AutoSize = true;
            this.lblPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevisto.Location = new System.Drawing.Point(141, 81);
            this.lblPrevisto.Name = "lblPrevisto";
            this.lblPrevisto.Size = new System.Drawing.Size(0, 18);
            this.lblPrevisto.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Previsto:";
            // 
            // lblArrecadado
            // 
            this.lblArrecadado.AutoSize = true;
            this.lblArrecadado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrecadado.Location = new System.Drawing.Point(142, 105);
            this.lblArrecadado.Name = "lblArrecadado";
            this.lblArrecadado.Size = new System.Drawing.Size(0, 18);
            this.lblArrecadado.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Arrecadado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 24);
            this.label5.TabIndex = 55;
            this.label5.Text = "Informações do mês atual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 24);
            this.label2.TabIndex = 56;
            this.label2.Text = "Informações dos últimos meses";
            // 
            // Mês
            // 
            this.Mês.HeaderText = "Mes";
            this.Mês.Name = "Mês";
            this.Mês.ReadOnly = true;
            this.Mês.Width = 150;
            // 
            // Previsto
            // 
            this.Previsto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Previsto.HeaderText = "Previsto (R$)";
            this.Previsto.Name = "Previsto";
            this.Previsto.ReadOnly = true;
            // 
            // Arrecadado
            // 
            this.Arrecadado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Arrecadado.HeaderText = "Arrecadado (R$)";
            this.Arrecadado.Name = "Arrecadado";
            this.Arrecadado.ReadOnly = true;
            // 
            // DadosFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblArrecadado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPrevisto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.label6);
            this.Name = "DadosFinanceiro";
            this.Text = "DadosFinanceiro";
            this.Load += new System.EventHandler(this.DadosFinanceiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mês;
        private System.Windows.Forms.DataGridViewTextBoxColumn Previsto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrecadado;
        private System.Windows.Forms.Label lblPrevisto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArrecadado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}