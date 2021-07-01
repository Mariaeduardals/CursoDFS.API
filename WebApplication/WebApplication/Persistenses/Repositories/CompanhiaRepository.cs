using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class CompanhiaRepository : BaseRepository, ICompanhiaRepository
    {
        private readonly AppDbContext _context;
        
        public CompanhiaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Companhia>> ListAsync()
        {
            return await _context.Companhia.ToListAsync();
        }

        public async Task AddAsync(Companhia companhia)
        { 
           await _context.Companhia.AddAsync(companhia);
        }
        
        public async Task<Companhia> FindByIdAsync(int id)
        {
            var companhiaProdutos = _context.Companhia.Include(company => company.Produtos).AsNoTracking();
            return await companhiaProdutos.FirstOrDefaultAsync(companhia => companhia.Id == id);
        }
        
        public void Update(Companhia companhia)
        {
            _context.Companhia.Update(companhia);
        }

        public void Remove(Companhia companhia)
        {
            _context.Companhia.Remove(companhia);
        }
    }
}