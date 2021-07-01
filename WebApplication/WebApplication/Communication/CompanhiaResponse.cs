using WebApplication.Dominio.Modelos;

namespace WebApplication.Communication
{
    public class CompanhiaResponse : BaseResponse
    {
        public Companhia Companhia { get; private set; }

        public CompanhiaResponse(bool success, string message, Companhia companhia) : base(success, message)
        {
            Companhia = companhia;
        }

        public CompanhiaResponse(Companhia companhia) : this(true, string.Empty, companhia)
        {
        }
        public CompanhiaResponse(string message) : this(false, message, null)
        {
        }

    }
}    