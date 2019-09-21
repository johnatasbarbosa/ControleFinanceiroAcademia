using ControleFinanceiroAcademia;
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
    public partial class Inicio : Form
    {
        List<string[]> rows = new List<string[]>();
        List<string[]> rowsExibidas = new List<string[]>();

        public Inicio()
        {
            AtualizarMeses();
            InitializeComponent();
            txtBuscar.KeyUp += new KeyEventHandler(txtBuscar_KeyUp);
            //comboProfessor.SelectedIndexChanged += new EventHandler(ComboBoxProfessor_SelectedIndexChanged);
            this.dgvAluno.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAluno_RowPrePaint);
        }

        private void dgvAluno_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (var i = 0; i < dgvAluno.Rows.Count; i++)
                if (Convert.ToBoolean(dgvAluno.Rows[i].Cells[0].Value))
                    dgvAluno.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Black;
            style.ForeColor = Color.Black;
            for (var i = 0; i < dgvAluno.Rows.Count; i++)
            {
                dgvAluno.Rows[i].Cells[2].Style = style;
            }            
        }

        private void AtualizarMeses()
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                var alunos = contexto.Alunos.Where(x => x.Ativo == true).Include("Ciclos.Meses").ToList();
                var mesAtual = DateTime.Now.Month;
                var anoAtual = DateTime.Now.Year;
                foreach (var aluno in alunos)
                {
                    var ultimoMesAluno = aluno.Ciclos.Last().Meses.OrderBy(a => a.Data).Last().Data.Month + 1;
                    var ultimoAnoAluno = aluno.Ciclos.Last().Meses.OrderBy(a => a.Data).Last().Data.Year;
                    //while ((ultimoMesAluno % 12) + 1 < mesAtual)
                    while ((ultimoMesAluno <= mesAtual) || (ultimoAnoAluno < anoAtual))
                    {
                        var mes = new Mes();
                        //var novoDia = aluno.DiaPagamento;
                        //if (ultimoMesAluno == 2 && aluno.DiaPagamento > 28)
                        //    novoDia = 28;
                        //else if ((ultimoMesAluno == 4 || ultimoMesAluno == 6 || ultimoMesAluno == 9 || ultimoMesAluno == 11) && aluno.DiaPagamento > 30)
                        //    novoDia = 30;
                        //mes.Data = new DateTime(ultimoAnoAluno, ultimoMesAluno, novoDia);
                        mes.Data = new Servicos().NovaDataPagamento(aluno.DiaPagamento, ultimoMesAluno, ultimoAnoAluno);
                        aluno.Ciclos.Last().Meses.Add(mes);
                        ultimoMesAluno++;
                        if (ultimoMesAluno == 13)
                        {
                            ultimoAnoAluno += 1;
                            ultimoMesAluno = 1;
                        }
                    }
                    //contexto.Entry(aluno).State = EntityState.Modified;
                }
                contexto.SaveChanges();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var newAluno = new NewAluno();
            newAluno.ShowDialog();
            CarregarTabela();
            AtualizarTabela();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarTabela();
                //using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
                //{
                //    var professores = contexto.Professores.Select(p => p.Nome).ToList();
                //    foreach (var professor in professores)
                //    {
                //        this.comboProfessor.Items.Add(professor);
                //    }
                //    this.comboProfessor.DropDownStyle = ComboBoxStyle.DropDownList;
                //}
                //this.comboProfessor.SelectedIndex = 0;

                this.rbAtivos.Checked = true;
            }
            catch (Exception)
            {

            }
        }
        
        private void dgvAluno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                var row = rowsExibidas[e.RowIndex];
                var id = Convert.ToInt32(row[row.Length - 1]);
                var aluno = contexto.Alunos.Include("Ciclos.Meses").FirstOrDefault(x => x.Id == id);
                if(e.ColumnIndex == 1)
                {
                    var newAluno = new NewAluno(aluno.Id);
                    newAluno.ShowDialog();
                    CarregarTabela();
                    AtualizarTabela();
                }
                else if(e.ColumnIndex == 2)
                {
                    var activateAluno = new ActivateAluno(aluno.Nome, aluno.Id);
                    activateAluno.ShowDialog();
                    CarregarTabela();
                    AtualizarTabela();
                }
                else
                {
                    var meses = aluno.Ciclos.LastOrDefault().Meses.OrderByDescending(x => x.Data).ToList();
                    if (14 - (e.ColumnIndex) < meses.Count)
                    {
                        var mes = meses.ElementAt(14 - (e.ColumnIndex));
                        var confirmacaoPagamento = new ConfirmacaoPagamento(aluno.Nome, mes.Id);
                        confirmacaoPagamento.ShowDialog();
                        CarregarTabela();
                        AtualizarTabela();
                    }
                }                
            }
        }

        private DataGridView CarregarTabela()
        {
            try
            {
                this.dgvAluno.Columns.Clear();
                this.dgvAluno.Rows.Clear();
                rows.Clear();
                string[] nomeMeses = { "Janei", "Fever", "Março", "Abril", "Maio", "Junho", "Julho", "Agost", "Setem", "Outub", "Novem", "Dezem" };
                var mesAtual = DateTime.Now.Month;

                //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                //dgvAluno.Columns.Add(btn);
                //btn.HeaderText = "_________NOME_DO_ALUNO________";
                //btn.Text = aluno.Nome;
                //btn.Name = "btnNome";
                //btn.UseColumnTextForButtonValue = true;
                //btn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                this.dgvAluno.Columns.Add(new DataGridViewCheckBoxColumn());
                this.dgvAluno.Columns[0].Name = "Situação";
                this.dgvAluno.Columns[0].Visible = false;
                this.dgvAluno.Columns.Add(new DataGridViewButtonColumn());
                //this.dgvAluno.ColumnCount = 1;
                this.dgvAluno.Columns[1].Name = "_________NOME_DO_ALUNO________";
                this.dgvAluno.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                this.dgvAluno.Columns.Add(new DataGridViewCheckBoxColumn());
                this.dgvAluno.Columns[2].Name = "Ativo";
                for (var i = 0; i < 12; i++)
                    this.dgvAluno.Columns.Add(new DataGridViewCheckBoxColumn());
                for (var i = 0; i < 12; i++)
                    this.dgvAluno.Columns[i + 3].Name = nomeMeses[(mesAtual + i) % 12];


                this.dgvAluno.AutoResizeColumns();

                using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
                {
                    var alunos = contexto.Alunos.Include("Ciclos.Meses").Include("Ciclos.Professor").ToList();
                    foreach (var aluno in alunos)
                    {
                        var atual = DateTime.Now;
                        string[] row = new string[17];

                        row[0] = (aluno.Ciclos.Last().Meses.Count(x => x.Pago == false) > 0).ToString();
                        row[1] = aluno.Nome;
                        row[2] = aluno.Ativo.ToString();
                    
                        var meses = aluno.Ciclos.LastOrDefault().Meses.OrderByDescending(x => x.Data).Take(12).ToList();
                        var mes = 14;
                        for (var i = 0; i < meses.Count; i++)
                        {
                            row[mes] = meses.ElementAt(i).Pago.ToString();
                            //row[mes] = "true";
                            mes--;
                        }
                        for (var i = mes; i > 2; i--)
                        {
                            row[i] = "False";
                            //mes--;
                        }


                        this.dgvAluno.Rows.Add(row);
                        row[15] = aluno.Ciclos.LastOrDefault().Professor.Nome;
                        row[16] = aluno.Id.ToString();
                        rows.Add(row);                        
                    }
                }
                this.dgvAluno.AllowUserToAddRows = false;
                this.dgvAluno.Rows[0].ReadOnly = true;

            }
            catch (Exception ex)
            {
                var a = ex;
            }
            return new DataGridView();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            AtualizarTabela();
        }

        private void ComboBoxProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
        
        private void AtualizarTabela()
        {
            dgvAluno.Rows.Clear();
            rowsExibidas.Clear();
            int indice = 0;
            for (var i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                //if (row[row.Count() - 2].ToUpper().Contains(comboProfessor.SelectedItem.ToString().ToUpper()) && row[1].ToUpper().Contains(txtBuscar.Text.ToUpper()) && (rbTodos.Checked || Convert.ToBoolean(row[row.Count() - 3])))
                if (row[1].ToUpper().Contains(txtBuscar.Text.ToUpper()) && (rbTodos.Checked || Convert.ToBoolean(row[2])))
                {
                    rowsExibidas.Add(row);
                    dgvAluno.Rows.Add(row);
                    this.dgvAluno.Rows[indice].ReadOnly = true;
                    indice++;
                }
            }
        }

        private void rbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.ShowDialog();
        }
    }
}
