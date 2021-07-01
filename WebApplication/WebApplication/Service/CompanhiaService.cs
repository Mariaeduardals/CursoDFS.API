using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Dominio.Services;

namespace WebApplication.Service
{
    public class CompanhiaService : ICompanhiaService
    {
        private readonly ICompanhiaRepository _companhiaRepository;
        private readonly IUnitOfWork _unitOfWork;
       
        public CompanhiaService(ICompanhiaRepository companhiaRepository,  IUnitOfWork unitOfWork)
        {
            _companhiaRepository = companhiaRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Companhia>> ListAsync()
        {
            return await _companhiaRepository.ListAsync();
        }
        public async Task<CompanhiaResponse> SaveAsync(Companhia companhia)
        {
            try
            {
                await _companhiaRepository.AddAsync(companhia);
                await _unitOfWork.CompleteAsync();

                return new CompanhiaResponse(companhia);
            }
            catch (Exception ex)
            {
            
                return new CompanhiaResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
        
        public async Task<CompanhiaResponse> UpdateAsync(int id, Companhia companhia)
        {
            var _companhia = await _companhiaRepository.FindByIdAsync(id);

            if (_companhia == null)
                return new CompanhiaResponse("Companhia not found.");

            _companhia.NomeFantasia = companhia.NomeFantasia;
            _companhia.RazaoSocial = companhia.RazaoSocial;
            _companhia.Cnpj = companhia.Cnpj;

            try
            {
                _companhiaRepository.Update(_companhia);
                await _unitOfWork.CompleteAsync();

                return new CompanhiaResponse(_companhia);
            }
            catch (Exception ex)
            {
                
                return new CompanhiaResponse($"An error occurred when updating the companhia: {ex.Message}");
            }
            
        }

        public async Task<CompanhiaResponse> DeleteAsync(int id)
        {
            try
            {
                var existingCompanhia = await _companhiaRepository.FindByIdAsync(id);

                if (existingCompanhia == null)
                    return new CompanhiaResponse("Companhia not found.");
               
                
                _companhiaRepository.Remove(existingCompanhia);
                await _unitOfWork.CompleteAsync();
                
                return new CompanhiaResponse(existingCompanhia);
            }
            catch (Exception ex)
            {
                
                return new CompanhiaResponse($"An error occurred when deleting the companhia: {ex.Message}");
            }
        }

        public Task<Companhia> FindByIdAsync(int id)
        {
            return _companhiaRepository.FindByIdAsync(id);
        }
    }
}