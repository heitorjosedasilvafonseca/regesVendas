using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Vendedores
    {
        [Key]
        public long? VendedoresId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório")]
        public string Celular { get; set; }

        [EmailAddress]
        [Display(Name = "Endereço de e-Mail")] 
        public string email { get; set; }
        [Display(Name = "Vlr. Meta Mensal")]
        public decimal ValorMeta { get; set; }
    }
}
