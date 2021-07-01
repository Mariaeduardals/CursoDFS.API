using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public abstract class BaseRepository
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}