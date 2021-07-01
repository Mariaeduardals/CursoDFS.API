using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly AppDbContext _context;
        
        public ProdutoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.FindAsync(id);
        }

        public void Update(Produto produto)
        {
            _context.Produto.Update(produto);
        }

        public void Remove(Produto produto)
        {
            _context.Produto.Remove(produto);
        }
    }
}