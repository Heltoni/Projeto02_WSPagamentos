using Projeto02_WSPagamentos.Enumerations;
using Projeto02_WSPagamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto02_WSPagamentos.Controllers
{
    public class PagamentosController : ApiController
    {

        static readonly PagamentosRepository repo =
            new PagamentosRepository();

        //HTTP GET - LISTA TODOS OS PAGAMENTOS
        public  IEnumerable<Pagamento> GetPagamentos()
        {
            return repo.BuscarPagamentos();
        }

        //HTTP POST - INCLUSÃO DE UM PAGAMENTO
        public HttpResponseMessage PostPagamento(Pagamento pagamento)
        {
            StatusPagto resposta = repo.Adicionar(pagamento);

            if (resposta != StatusPagto.PAGAMENTO_OK)
            {
                string mensagem = "ERRO: ";
                switch (resposta)
                {
                    case StatusPagto.CARTAO_INEXISTENTE:
                        mensagem += "O cartão informado: " + 
                            pagamento.NumeroCartao + 
                            " não existe!";
                        break;
                    case StatusPagto.PAGAMENTO_JA_EFETUADO:
                        mensagem += "O pagamento do pedido: " +
                            pagamento.NumeroPedido +
                            " já foi realizado!";
                        break;
                    case StatusPagto.SALDO_INSULFICIENTE:
                        mensagem += "Não há saldo suficiente no cartão " +
                            pagamento.NumeroCartao;
                        break;
                    default:
                        break;
                }

                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no Servidor"),
                    ReasonPhrase = mensagem
                };

                throw new HttpResponseException(erro);

            }

            //OK, PAGAMENTO FOI REALIZADO

            var response = Request.CreateResponse<Pagamento>(
                HttpStatusCode.Created, pagamento);

            string uri = Url.Link("DefaultApi", new { id = pagamento.PagamentoID });

            return response;

        }

    }
}
