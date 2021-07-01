using WebApplication.Dominio.Modelos;

namespace WebApplication.Communication
{
    public class CompraResponse : BaseResponse
    {
        public Compra Compra { get; private set; }
        
        public CompraResponse(bool success, string message, Compra compra) : base(success, message)
        {
            Compra = compra;
        }
       
        public CompraResponse(Compra compra) : this(true, string.Empty, compra)
        {
        }

       
        public CompraResponse(string message) : this(false, message, null)
        {
        }
    }
}