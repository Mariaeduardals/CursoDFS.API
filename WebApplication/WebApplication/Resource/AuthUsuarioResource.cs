using System.ComponentModel.DataAnnotations;

namespace WebApplication.Resource
{
    public class AuthUsuarioResource
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string Password { get; set; }
    }
}