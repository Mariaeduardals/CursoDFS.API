using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListAsync();

        Task<ProdutoResponse> SaveAsync(Produto produto);
        
        Task<ProdutoResponse> UpdateAsync(int id, Produto produto);

        Task<ProdutoResponse> DeleteAsync(int id);
        Task<Produto> FindByIdAsync(int id);
        
    }
}