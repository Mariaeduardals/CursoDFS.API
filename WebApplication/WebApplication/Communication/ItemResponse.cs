using System;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Communication
{
    public class ItemResponse: BaseResponse
    {
        public Item Item { get; set; }
        
        public ItemResponse(bool success, string message, Item item) : base(success, message)
        {
            Item = item;
        }
        
        public ItemResponse(Item item) : this(true, string.Empty, item)
        {
        }
       
        public ItemResponse(string message) : this(false, message, null)
        {
        }
    }
}