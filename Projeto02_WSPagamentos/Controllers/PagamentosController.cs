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
    }
}
