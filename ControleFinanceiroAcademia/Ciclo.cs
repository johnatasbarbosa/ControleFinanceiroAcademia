using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    [Table("Ciclos")]
    class Ciclo
    {
        public int Id { get; set; }

        public Plano Plano { get; set; }

        public List<Mes> Meses { get; set; }

        public DateTime? DataFinal { get; set; }

        public Professor Professor { get; set; }

        public Aluno Aluno { get; set; }

        public float? ValorPromocional { get; set; }
    }
}
