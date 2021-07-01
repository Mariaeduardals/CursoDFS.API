using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Repositories
{
    public interface IItemRepository
    {
        public  Task<IEnumerable<Item>> FindCompraIdAsync(int id);
       
    }
}