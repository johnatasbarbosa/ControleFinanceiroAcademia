using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    [Table("Meses")]
    class Mes
    {
        public Mes()
        {
            DiaPagamento = null;
        }

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public bool Pago { get; set; }

        public DateTime? DiaPagamento { get; set; }

        public Ciclo Ciclo { get; set; }
    }
}
