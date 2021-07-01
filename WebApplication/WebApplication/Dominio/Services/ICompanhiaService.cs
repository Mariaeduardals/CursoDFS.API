using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;
using WebApplication.Resource;

namespace WebApplication.Dominio.Services
{
    public interface ICompanhiaService
    {
        Task<IEnumerable<Companhia>> ListAsync();
        
        Task<CompanhiaResponse> SaveAsync(Companhia companhia);
        
        Task<CompanhiaResponse> UpdateAsync(int id, Companhia companhia);

        Task<CompanhiaResponse> DeleteAsync(int id);
        
        Task<Companhia> FindByIdAsync(int id);
    }
}