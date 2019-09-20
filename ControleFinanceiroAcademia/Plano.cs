using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    [Table("Planos")]
    class Plano
    {
        public int Id { get; set; }

        public int QuantidadeDias { get; set; }

        public float Valor { get; set; }
    }
}
