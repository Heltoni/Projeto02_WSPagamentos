using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto02_WSPagamentos.Models
{
    public class Pagamento
    {

        [Required]        
        [Key]
        public int PagamentoID { get; set; }
                
        public int ClienteID { get; set; }
        public string NumeroCartao { get; set; }
        public string NumeroPedido { get; set; }
        public double ValorPagto { get; set; }
        public Cliente ClienteInfo { get; set; }

    }
}