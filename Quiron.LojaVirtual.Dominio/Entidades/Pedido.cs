using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage = "Informe seu nome")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "Cep:")]
        public string CEP { get; set; }

        [Display(Name = "Endereço:")]
        [Required(ErrorMessage = "Informe o endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        [Display(Name = "Cidade:")]
        [Required(ErrorMessage = "Informe a Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "Informe o Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public string Estado { get; set; }

        public bool EmbrulhaPresente { get; set; }

    }
}
