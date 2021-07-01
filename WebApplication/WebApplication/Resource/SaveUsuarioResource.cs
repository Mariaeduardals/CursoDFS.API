using System.ComponentModel.DataAnnotations;

namespace WebApplication.Resource
{
    public class SaveUsuarioResource
    {
        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Number of document invalid!.")]
        public string Cpf { get; set; }
    }
}