using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    [Table("Alunos")]
    class Aluno
    {
        public Aluno()
        {
            Ativo = true;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public int DiaPagamento { get; set; }

        public float Peso { get; set; }

        public float Braco { get; set; }

        public float Abs { get; set; }

        public float Gluteo { get; set; }

        public float Perna { get; set; }

        public float IMC { get; set; }
        
        public List<Ciclo> Ciclos { get; set; }

        public bool Ativo { get; set; }

        public string Telefone { get; set; }

    }
}
