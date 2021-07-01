using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Repositories
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Compra>> ListAsync();
        Task AddAsync(Compra companhia);
        
        Task<Compra> FindByIdAsync(int id);

        void Update(Compra compra);

        void Remove(Compra compra);
    }
}