using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Clientes
    {
        [Key]
        public long? ClientesId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(40, ErrorMessage = "Digite endereço com no máximo de 40 caracteres")]
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        [Display(Name = "U.F.")]
        public string Uf { get; set; }

        public string Cep { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório")]
        public string Celular { get; set; }

        [EmailAddress]
        [Display(Name = "Endereço de e-Mail")]
        public string email { get; set; }
    }
}
