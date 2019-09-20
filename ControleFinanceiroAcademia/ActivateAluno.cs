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
    public partial class ActivateAluno : Form
    {
        ControleAcademiaContexto contexto = new ControleAcademiaContexto();
        Aluno aluno;

        public ActivateAluno(string nomeAluno, int idAluno)
        {
            this.aluno = contexto.Alunos.Include("Ciclos.Meses").Include("Ciclos.Professor").Include("Ciclos.Plano").FirstOrDefault(x => x.Id == idAluno);
            InitializeComponent();
        }

        private void ActivateAluno_Load(object sender, EventArgs e)
        {
            txtAluno.Text = aluno.Nome;
            txtAluno.ReadOnly = true;
            txtData.Text = DateTime.Now.ToShortDateString();

            if (aluno.Ativo)
            {
                labelTitulo.Text = "Desativar aluno";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (aluno.Ativo)
                {
                    var data = Convert.ToDateTime(txtData.Text);
                    aluno.Ciclos.Last().DataFinal = data;
                    
                    var ano = data.Year;
                    var mes = data.Month;
                    var meses = aluno.Ciclos.Last().Meses;
                    meses.Reverse();
                    for (var i = 0; i < meses.Count; i++)
                    {
                        if (DateTime.Compare(meses[i].Data, data) >= 0)
                        {
                            //aluno.Ciclos.Last().Meses.Remove(meses[i]);
                            contexto.Meses.Remove(meses[i]);
                            i--;
                        }
                    }
                }
                else
                {
                    var ciclo = new Ciclo();
                    ciclo.Meses = new List<Mes>();
                    var mes = new Mes();
                    mes.Data = Convert.ToDateTime(txtData.Text);
                    ciclo.Meses.Add(mes);
                    ciclo.Plano = aluno.Ciclos.Last().Plano;
                    ciclo.Professor = aluno.Ciclos.Last().Professor;
                    aluno.Ciclos.Add(ciclo);
                }
                aluno.Ativo = !aluno.Ativo;

                contexto.Entry(aluno).State = EntityState.Modified;
                contexto.SaveChanges();

                this.Close();
            }
            catch (FormatException f)
            {
                var ks = f;
            }
            catch (Exception ex)
            {
                var a = ex;
            }
        }
        
    }
}
