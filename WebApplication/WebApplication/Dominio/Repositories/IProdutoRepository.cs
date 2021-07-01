using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ListAsync();
        Task AddAsync(Produto companhia);
        
        Task<Produto> FindByIdAsync(int id);

        void Update(Produto produto);

        void Remove(Produto produto);
    }
}