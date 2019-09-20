using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiroAcademia
{
    public class Servicos
    {
        public DateTime NovaDataPagamento(int dia, int mes, int ano)
        {
            if (mes == 2 && dia > 28)
                dia = 28;
            else if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia > 30)
                dia = 30;

            return new DateTime(ano, mes, dia);
        }
    }
}
