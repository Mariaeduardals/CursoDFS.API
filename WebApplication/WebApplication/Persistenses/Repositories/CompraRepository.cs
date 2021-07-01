using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class CompraRepository : BaseRepository, ICompraRepository
    {
        private readonly AppDbContext _context;
        
        public CompraRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Compra>> ListAsync()
        {
            return await _context.Compra.ToListAsync();
        }

        public async Task AddAsync(Compra compra)
        {
            await _context.Compra.AddAsync(compra);
        }

        public async Task<Compra> FindByIdAsync(int id)
        {
            var compraCartao = _context.Compra.Include(p => p.Items).AsNoTracking();

            return await compraCartao.FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Compra compra)
        {
            _context.Compra.Update(compra);
        }

        public void Remove(Compra compra)
        {
            _context.Compra.Remove(compra);
        }
    }
}