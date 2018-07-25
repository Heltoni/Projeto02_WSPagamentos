using Projeto02_WSPagamentos.Enumerations;
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

        public StatusPagto Adicionar(Pagamento pagamento)
        {
            using (var ctx = new PagamentosContext())
            {
                //verificar se o cartão existe
                var cartao = ctx.Clientes
                    .FirstOrDefault(
                    c => c.NumeroCartao.Equals(pagamento.NumeroCartao));
                if (cartao == null)
                {
                    return StatusPagto.CARTAO_INEXISTENTE;
                }

                var pagto = ctx.Pagamentos
                    .FirstOrDefault(
                    p => p.NumeroPedido.Equals(pagamento.NumeroPedido));

                if (pagto != null)
                {
                    return StatusPagto.PAGAMENTO_JA_EFETUADO;
                }
            }
        }

    }
}