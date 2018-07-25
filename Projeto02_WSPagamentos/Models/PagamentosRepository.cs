using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto02_WSPagamentos.Models
{
    public class PagamentosRepository
    {
        public IEnumerable<Pagamento> BuscarPagamentos()
        {
            using (var ctx = new PagamentosContext())
            {
                return ctx.Pagamentos.ToList<Pagamento>();
            }
        }



    }
}