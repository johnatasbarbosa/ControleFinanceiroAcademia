using ControleAcademia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiroAcademia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
            {
               if(contexto.Usuarios.FirstOrDefault(x => x.NomeUsuario == txtUsuario.Text && x.Senha == txtSenha.Text && x.Administrador) != null)
                {
                    var dados = new DadosFinanceiro();
                    dados.Show();

                    this.Close();
                }
                else
                {
                    labelIncorreto.ForeColor = Color.Red;
                    labelIncorreto.Visible = true;
                }
            }
        }



        //Usuario Logar(string nomeUsuario, string senha)
        //{
        //    UnicodeEncoding encoding = new UnicodeEncoding();
        //    byte[] hashBytes;
        //    using(HashAlgorithm hash = SHA1.Create())
        //    {
        //        hashBytes = hash.ComputeHash(encoding.GetBytes(senha));
        //    }
        //    StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
        //    foreach(byte b in hashBytes)
        //    {
        //        hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
        //    }

        //    senha = hashValue.ToString();

        //    using (ControleAcademiaContexto contexto = new ControleAcademiaContexto())
        //    {
        //        string bKey = Convert.FromBase64String("JPro").ToString();
        //        byte[] bText = new UTF8Encoding().GetBytes(senha);
        //        var usuario = contexto.Usuarios.FirstOrDefault(x => x.NomeUsuario == nomeUsuario && x.Senha == senha);
        //        return usuario;
        //    }
        //}

    }
}
