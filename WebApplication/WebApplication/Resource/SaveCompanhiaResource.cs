using System.ComponentModel.DataAnnotations;

namespace WebApplication.Resource
{
    public class SaveCompanhiaResource
    {
        
        [Required]
        [MaxLength(45)]
        public string NomeFantasia { get; set; }
        [Required]
        [MaxLength(45)]
        public string RazaoSocial { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{14}$",ErrorMessage = "Number of document invalid!.")]
        public string Cnpj { get; set; }
    }
}