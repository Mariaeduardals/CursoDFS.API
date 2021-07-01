using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        private readonly AppDbContext _context;
        
        public ItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Item>> FindCompraIdAsync(int id)
        {
            var itemsCompra = _context.Items.Include(p => p.Produto).AsNoTracking();
            var items = await itemsCompra.ToListAsync();
            return items.FindAll(p => p.CompraId == id);
        }

    }
}