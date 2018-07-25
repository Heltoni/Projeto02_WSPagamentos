using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto02_WSPagamentos.Models
{    
    public class Cliente
    {

        public Cliente()
        {
            this.Pagamentos = new HashSet<Pagamento>();
        }


        [Required]
        [Display(Name = "Id do Cliente")]   
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "O Nome do cliente é obrigatório!")]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Número do Cartão")]
        public string NumeroCartao { get; set; }

        [Required]
        public double Limite { get; set; }
        
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}