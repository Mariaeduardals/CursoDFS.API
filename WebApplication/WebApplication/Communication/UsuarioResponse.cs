using WebApplication.Dominio.Modelos;

namespace WebApplication.Communication
{
    public class UsuarioResponse : BaseResponse
    {
        public Usuario Usuario { get; private set; }
        
        public UsuarioResponse(bool success, string message, Usuario usuario) : base(success, message)
        {
            Usuario = usuario;
        }
        
        public UsuarioResponse(Usuario usuario) : this(true, string.Empty, usuario)
        {
        }

        public UsuarioResponse(string message) : this(false, message, null)
        {
        }
    }
}