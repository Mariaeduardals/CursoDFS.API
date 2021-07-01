using WebApplication.Dominio.Modelos;

namespace WebApplication.Communication
{
    public class ProdutoResponse : BaseResponse
    {
        public Produto Produto { get; private set; }
        
        public ProdutoResponse(bool success, string message, Produto produto) : base(success, message)
        {
            Produto = produto;
        }
        
        public ProdutoResponse(Produto produto) : this(true, string.Empty, produto)
        {
        }
       
        public ProdutoResponse(string message) : this(false, message, null)
        {
        }
    }
}