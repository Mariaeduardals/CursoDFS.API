using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebApplication.Dominio.Modelos
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [JsonProperty]
        [JsonInclude]
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }
       
        [Newtonsoft.Json.JsonIgnore]
        public Compra Compra { get; set; }
        public int CompraId { get; set; }

    }
}