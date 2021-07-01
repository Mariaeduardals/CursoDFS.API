using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> FindCompraIdAsync(int id);
    }
}