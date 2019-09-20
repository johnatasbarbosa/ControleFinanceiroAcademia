using ControleFinanceiroAcademia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleAcademia
{
    public partial class NewAluno : Form
    {
        public NewAluno()
        {
            InitializeComponent();
            comboPlanos.SelectedIndexChanged += new EventHandler(ComboBoxPlanos_SelectedIndexChanged);
        }

        int idAluno = 0;
        public NewAluno(int idAluno)
        {
            this.idAluno = idAluno;
            InitializeComponent();
            comboPlanos.SelectedIndexChanged += new EventHandler(ComboBoxPlanos_SelectedIndexChanged);
        }

        private void NewAluno_Load(object sender, EventArgs e)
        {
            try
            {
                if(idAluno == 0)
                {
                    this.comboDiaPagamento.SelectedIndex = 0;
                    txtInicio.Text = DateTime.Now.ToShortDateString();

                    using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
                    {
                        //    var professores = contexto.Professores.Select(p => p.Nome).ToList();
                        //    foreach(var professor in professores)
                        //    {
                        //        this.comboProfessores.Items.Add(professor);
                        //    }
                        //    this.comboProfessores.DropDownStyle = ComboBoxStyle.DropDownList;
                        //    this.comboProfessores.SelectedIndex = 0;

                        var planos = contexto.Planos.Select(p => p.QuantidadeDias).ToList();
                        foreach (var plano in planos)
                        {
                            this.comboPlanos.Items.Add(plano + " dias");
                        }
                        this.comboPlanos.DropDownStyle = ComboBoxStyle.DropDownList;
                        this.comboPlanos.SelectedIndex = 0;
                        btnEdit.Visible = false;
                        labelEdit.Visible = false;
                    }
                }
                else
                {

                    using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
                    {
                        var aluno = contexto.Alunos.Include("Ciclos.Professor").Include("Ciclos.Plano").FirstOrDefault(x => x.Id == idAluno);

                        var i = 0;
                        var j = 0;
                        //var professores = contexto.Professores.Select(p => p.Nome).ToList();
                        //foreach (var professor in professores)
                        //{
                        //    this.comboProfessores.Items.Add(professor);
                        //    if (professor == aluno.Ciclos.Last().Professor.Nome)
                        //        i = j;
                        //    j++;
                        //}
                        //this.comboProfessores.DropDownStyle = ComboBoxStyle.DropDownList;
                        //comboProfessores.SelectedIndex = i;

                        i = 0;
                        j = 0;
                        var planos = contexto.Planos.Select(p => p.QuantidadeDias).ToList();
                        foreach (var plano in planos)
                        {
                            this.comboPlanos.Items.Add(plano + " dias");
                            if (plano == aluno.Ciclos.Last().Plano.QuantidadeDias)
                                i = j;
                            j++;
                        }
                        this.comboPlanos.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboPlanos.SelectedIndex = i;

                        this.txtValor.Text = aluno.Ciclos.LastOrDefault().ValorPromocional.HasValue ? aluno.Ciclos.LastOrDefault().ValorPromocional.Value.ToString() : aluno.Ciclos.LastOrDefault().Plano.Valor.ToString();

                        txtNome.Text = aluno.Nome;
                        txtTelefone.Text = aluno.Telefone;
                        comboDiaPagamento.SelectedIndex = aluno.DiaPagamento - 1;
                        txtDataNascimento.Text = aluno.DataNascimento.ToShortDateString();
                        txtAbs.Text = aluno.Abs.ToString();
                        txtBraco.Text = aluno.Braco.ToString();
                        txtGluteo.Text = aluno.Gluteo.ToString();
                        txtIMC.Text = aluno.IMC.ToString();
                        txtPerna.Text = aluno.Perna.ToString();
                        txtPeso.Text = aluno.Peso.ToString();

                        labelInicio.Visible = false;
                        txtInicio.Visible = false;
                        btnAdd.Visible = false;
                        labelNew.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                try
                {
                    if (txtNome.Text == "")
                        throw new Exception();

                    var aluno = new Aluno();

                    //aluno.Inicio = Convert.ToDateTime(txtInicio.Text);
                    aluno.Nome = txtNome.Text;
                    aluno.Telefone = txtTelefone.Text;
                    aluno.DiaPagamento = Convert.ToInt32(comboDiaPagamento.SelectedItem);
                    aluno.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                    aluno.Abs = txtAbs.Text == "" ? 0 : float.Parse(txtAbs.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Braco = txtBraco.Text == "" ? 0 : float.Parse(txtBraco.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Gluteo = txtGluteo.Text == "" ? 0 : float.Parse(txtGluteo.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.IMC = txtIMC.Text == "" ? 0 : float.Parse(txtIMC.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Perna = txtPerna.Text == "" ? 0 : float.Parse(txtPerna.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Peso = txtPeso.Text == "" ? 0 : float.Parse(txtPeso.Text, CultureInfo.InvariantCulture.NumberFormat);

                    List<Ciclo> ciclos = new List<Ciclo>();
                    var ciclo = new Ciclo();
                    ciclo.Professor = contexto.Professores.FirstOrDefault();
                    var planos = contexto.Planos.ToList();
                    ciclo.Plano = planos.ElementAt(comboPlanos.SelectedIndex);
                    float valorPromocional = float.Parse(this.txtValor.Text);
                    if (valorPromocional != ciclo.Plano.Valor)
                        ciclo.ValorPromocional = valorPromocional;
                    
                    List<Mes> meses = new List<Mes>();
                    var mes = new Mes();
                    var data = Convert.ToDateTime(txtInicio.Text);
                    //var novoDia = aluno.DiaPagamento;
                    //if (data.Month == 2 && aluno.DiaPagamento > 28)
                    //    novoDia = 28;
                    //else if ((data.Month == 4 || data.Month == 6 || data.Month == 9 || data.Month == 11) && aluno.DiaPagamento > 30)
                    //    novoDia = 30;
                    //mes.Data = new DateTime(data.Year, data.Month, novoDia);
                    mes.Data = new Servicos().NovaDataPagamento(data.Day, data.Month, data.Year);
                    meses.Add(mes);
                    ciclo.Meses = meses;

                    ciclos.Add(ciclo);
                    aluno.Ciclos = ciclos;

                    contexto.Alunos.Add(aluno);
                    contexto.SaveChanges();

                    this.Close();
                }
                catch (Exception te)
                {
                    var a = te;
                    this.labelAviso.Text = "Não seja burro! Preencha as informações direito.";
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                try
                {
                    if (txtNome.Text == "")
                        throw new Exception();

                    var aluno = contexto.Alunos.Include("Ciclos.Professor").Include("Ciclos.Meses").FirstOrDefault(x => x.Id == idAluno);

                    aluno.Nome = txtNome.Text;
                    aluno.Telefone = txtTelefone.Text;
                    aluno.DiaPagamento = Convert.ToInt32(comboDiaPagamento.SelectedItem);
                    aluno.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                    aluno.Abs = txtAbs.Text == "" ? 0 : float.Parse(txtAbs.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Braco = txtBraco.Text == "" ? 0 : float.Parse(txtBraco.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Gluteo = txtGluteo.Text == "" ? 0 : float.Parse(txtGluteo.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.IMC = txtIMC.Text == "" ? 0 : float.Parse(txtIMC.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Perna = txtPerna.Text == "" ? 0 : float.Parse(txtPerna.Text, CultureInfo.InvariantCulture.NumberFormat);
                    aluno.Peso = txtPeso.Text == "" ? 0 : float.Parse(txtPeso.Text, CultureInfo.InvariantCulture.NumberFormat);

                    var planos = contexto.Planos.ToList();
                    //aluno.Ciclos.Last().Professor = contexto.Professores.FirstOrDefault();
                    var novoPlano = planos.ElementAt(comboPlanos.SelectedIndex);
                    float valorPromocional = float.Parse(this.txtValor.Text);
                    var ultimoCiclo = aluno.Ciclos.Last();
                    if (
                        (novoPlano.Id != ultimoCiclo.Plano.Id) || 
                        (
                            (ultimoCiclo.ValorPromocional.HasValue == false && valorPromocional != ultimoCiclo.Plano.Valor) || 
                            (ultimoCiclo.ValorPromocional.HasValue == true && ultimoCiclo.ValorPromocional.Value != valorPromocional))
                        )
                    {
                        aluno.Ciclos.Last().DataFinal = DateTime.Now;

                        var data = DateTime.Now;
                        if(aluno.Ciclos.Last().Meses != null && aluno.Ciclos.Last().Meses.Count > 0 && aluno.Ciclos.Last().Meses.Last().Data.Month == data.Month && aluno.Ciclos.Last().Meses.Last().Data.Year == data.Year)
                        {
                            //apagar do antigo e gerar um novo no novo ciclo
                            var ultimoMes = aluno.Ciclos.Last().Meses.Last();
                            aluno.Ciclos.Last().Meses.Remove(ultimoMes);
                            contexto.Meses.Remove(ultimoMes);
                        }

                        var ciclo = new Ciclo();
                        ciclo.Meses = new List<Mes>();
                        var mes = new Mes();
                        mes.Data = new Servicos().NovaDataPagamento(aluno.DiaPagamento, data.Month, data.Year);
                        ciclo.Meses.Add(mes);
                        ciclo.Plano = novoPlano;
                        if (valorPromocional != aluno.Ciclos.Last().Plano.Valor)
                            ciclo.ValorPromocional = valorPromocional;
                        ciclo.Professor = aluno.Ciclos.Last().Professor;
                        aluno.Ciclos.Add(ciclo);
                    }
                    //aluno.Ciclos.Last().Plano = novoPlano;
                    //if (valorPromocional != aluno.Ciclos.Last().Plano.Valor)
                    //    aluno.Ciclos.Last().ValorPromocional = valorPromocional;
                    
                    contexto.SaveChanges();

                    this.Close();
                }
                catch (Exception ex)
                {
                    this.labelAviso.Text = "Não seja burro! Preencha as informações direito.";
                    var exp = ex;
                }
            }
        }

        private void ComboBoxPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
                var planos = contexto.Planos.ToList();
                this.txtValor.Text = planos.ElementAt(comboPlanos.SelectedIndex).Valor.ToString();
            }
        }
        
    }
}
