using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> ListAsync();
        //Task<Usuario> FirstOrDefaultAsync(string login, string password);
        
        Task AddAsync(Usuario usuario);
        
        Task<Usuario> FindByIdAsync(int id);

        void Update(Usuario usuario);

        void Remove(Usuario usuario);

        Task<Usuario> FirstOrDefaultAsync(string email, string password);
    }
}