using System.Threading.Tasks;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}