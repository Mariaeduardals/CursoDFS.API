using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Services
{
    public interface ICompraService
    {
    Task<IEnumerable<Compra>> ListAsync();
    Task<CompraResponse> SaveAsync(Compra compra);
        
    Task<CompraResponse> UpdateAsync(int id, Compra compra);

    Task<CompraResponse> DeleteAsync(int id);

    Task<Compra> FindByIdAsync(int id);
    }
}