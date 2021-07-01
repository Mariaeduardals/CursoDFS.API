using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Dominio.Repositories
{
    public interface ICompanhiaRepository
    {
        Task<IEnumerable<Companhia>> ListAsync();
        Task AddAsync(Companhia companhia);
        
        Task<Companhia> FindByIdAsync(int id);

        void Update(Companhia companhia);

        void Remove(Companhia companhia);
    }
}