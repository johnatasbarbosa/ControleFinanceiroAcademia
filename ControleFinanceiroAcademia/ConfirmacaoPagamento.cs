using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAcademia
{
    public partial class ConfirmacaoPagamento : Form
    {
        ControleAcademiaContexto contexto = new ControleAcademiaContexto();
        string nomeAluno;
        Mes mes;
        Aluno aluno;

        public ConfirmacaoPagamento(string nomeAluno, int idMes)
        {
            this.nomeAluno = nomeAluno;
            this.mes = contexto.Meses.FirstOrDefault(x => x.Id == idMes);
            this.aluno = contexto.Alunos.Include("Ciclos.Plano").FirstOrDefault(x => x.Ciclos.Count(a => a.Meses.Count(q => q.Id == idMes) > 0) > 0);
            InitializeComponent();
        }

        private void ConfirmacaoPagamento_Load(object sender, EventArgs e)
        {
            string[] nomeMeses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            txtAluno.Text = nomeAluno;
            labelValor.Text = labelValor.Text + (aluno.Ciclos.Last().ValorPromocional.HasValue ? aluno.Ciclos.Last().ValorPromocional.Value : aluno.Ciclos.Last().Plano.Valor).ToString();
            txtAluno.ReadOnly = true;
            txtMes.Text = nomeMeses[mes.Data.Month - 1];
            txtMes.ReadOnly = true;
            txtData.Text = DateTime.Now.ToShortDateString();
            if (mes.Pago)
            {
                txtData.Text = "";
                txtData.ReadOnly = true;
                labelTitulo.Text = "Desfazer pagamento?";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mes.Pago = !mes.Pago;
            if(mes.Pago)
                mes.DiaPagamento = Convert.ToDateTime(txtData.Text);
            else
                mes.DiaPagamento = null;

            contexto.Entry(mes).State = EntityState.Modified;
            contexto.SaveChanges();
            
            this.Close();
        }
    }
}
