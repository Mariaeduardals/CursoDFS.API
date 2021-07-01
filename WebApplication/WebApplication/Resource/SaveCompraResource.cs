using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication.Dominio.Helpers;

namespace WebApplication.Resource
{
    public class SaveCompraResource
    {
        [Required] 
        public double Preco { get; set; }
        [Required]
        public FormaPag FormaPag { get; set; }
        [Required]
        public StatusCompra StatusCompra { get; set; }
        [MaxLength(255)]
        public string Observacao { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Zip code invalid!")]
        [Required]
        public string Cep { get; set; }
        [MaxLength(255)]
        public string Endereco { get; set; }
        public ISet<SaveItemResource> Items { get; set; }

    }
}