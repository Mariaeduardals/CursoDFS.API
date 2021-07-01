using System.ComponentModel.DataAnnotations;

namespace WebApplication.Resource
{
    public class SaveProdutoResource
    {
        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [MaxLength(255)]
        public string Observacao { get; set; }
        [Required]
        public int CompanhiaId { get; set; }
    }
}