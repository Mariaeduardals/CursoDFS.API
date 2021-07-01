using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Services
{
    public interface IUsuarioService
    {
        
        Task<UsuarioResponse> SaveAsync(Usuario usuario);
        
        Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario);

        Task<UsuarioResponse> DeleteAsync(int id);
        Task<IEnumerable<Usuario>> ListAsync();
        Task<Usuario> FindByIdAsync(int id);
        public Task<Usuario> FirstOrDefaultAsync(string usuarioEmail, string usuarioPassword);
    }
}