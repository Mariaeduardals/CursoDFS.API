using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Persistenses.Context;

namespace WebApplication.Persistenses.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly AppDbContext _context;
        
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            var usuarioCompra =  _context.Usuario.Include(user => user.Compra).AsNoTracking();
            return await usuarioCompra.FirstOrDefaultAsync(user => user.Id == id);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
        }

        public void Remove(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
        }
        public async Task<Usuario> FirstOrDefaultAsync(string email, string password)
        {
            return await _context.Usuario.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
    }
}