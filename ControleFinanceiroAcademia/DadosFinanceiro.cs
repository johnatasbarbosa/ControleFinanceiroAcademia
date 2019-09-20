using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAcademia
{
    public partial class DadosFinanceiro : Form
    {
        public DadosFinanceiro()
        {
            InitializeComponent();
        }

        private void DadosFinanceiro_Load(object sender, EventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                try
                {
                    var mesAtual = DateTime.Now.Month;
                    var anoAtual = DateTime.Now.Year;
                    
                    lblPrevisto.Text = contexto.Meses.Sum(x =>
                            (x.Data.Month == mesAtual && x.Data.Year == anoAtual) ?
                            (
                                x.Ciclo.ValorPromocional.HasValue ? x.Ciclo.ValorPromocional.Value : x.Ciclo.Plano.Valor
                            )
                            : 0
                        ).ToString();

                    lblArrecadado.Text = contexto.Meses.Sum(x =>
                            ((x.Data.Month == mesAtual && x.Data.Year == anoAtual) &&
                            x.Pago) ?
                            (
                                x.Ciclo.ValorPromocional.HasValue ? x.Ciclo.ValorPromocional.Value : x.Ciclo.Plano.Valor
                            )
                            : 0
                        ).ToString();
                    

                    string[] row = new string[6];
                    for (var  i = -1; i > -7; i--)
                    {
                        var dataAtual = DateTime.Now.AddMonths(i);
                        mesAtual = dataAtual.Month;
                        anoAtual = dataAtual.Year;

                        row[0] = mesAtual + "/" + anoAtual;
                        
                        //previsto
                        row[1] = contexto.Meses.Sum(x =>
                            (x.Data.Month == mesAtual && x.Data.Year == anoAtual) ?
                            (
                                x.Ciclo.ValorPromocional.HasValue ? x.Ciclo.ValorPromocional.Value : x.Ciclo.Plano.Valor
                            )
                            : 0
                        ).ToString();

                        //arrecadado
                        row[2] = contexto.Meses.Sum(x =>
                            ((x.Data.Month == mesAtual && x.Data.Year == anoAtual) &&
                            x.Pago) ?
                            (
                                x.Ciclo.ValorPromocional.HasValue ? x.Ciclo.ValorPromocional.Value : x.Ciclo.Plano.Valor
                            )
                            : 0
                        ).ToString();
                        
                        dgvDados.Rows.Add(row);
                    }
                    
                }
                catch (Exception ex)
                {
                    var a = ex;
                }
            }
        }
    }
}
