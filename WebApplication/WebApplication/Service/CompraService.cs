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
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
         private readonly IUnitOfWork _unityOfWork;
        
        public CompraService(ICompraRepository compraRepository, IUnitOfWork unitOfWork)
        {
            _compraRepository = compraRepository;
            _unityOfWork = unitOfWork;
        }
        public async Task<CompraResponse> SaveAsync(Compra compra)
        {
            try
            {
                await _compraRepository.AddAsync(compra);
                await _unityOfWork.CompleteAsync();
                return new CompraResponse(compra);
            }
            catch (Exception e)
            {
                return new CompraResponse($"An error occurred {e.Message}");
            }
        }

        
        public async Task<CompraResponse> UpdateAsync(int id, Compra compra)
        {
            try
            {
                var _compra = await _compraRepository.FindByIdAsync(id);
                 
                if (_compra == null) return new CompraResponse($"this purchase doesn't exists by id {id}");

                _compra.Endereco = compra.Endereco;
                _compra.Observacao = compra.Observacao;
                _compra.Valor = compra.Valor;
                _compra.Items = compra.Items;
                _compra.Status = compra.Status;
                _compra.FormaPagamento = compra.FormaPagamento;
                
                _compraRepository.Update(_compra);
                await _unityOfWork.CompleteAsync();

                return new CompraResponse(_compra);

            }
            catch (Exception e)
            {
                return new CompraResponse($"An error occurred {e.Message}");
            }
        }

        
        public async Task<CompraResponse> DeleteAsync(int id)
        {
            try
            {
                var compra = await _compraRepository.FindByIdAsync(id);
                if (compra == null) return new CompraResponse($"this purchase doesn't exists by id {id}");
                
                _compraRepository.Remove(compra);
                await _unityOfWork.CompleteAsync();

                return new CompraResponse(compra);

            }
            catch (Exception e)
            {
                return new CompraResponse($"An error occurred {e.Message}");
            }
        }

        
        public async Task<Compra> FindByIdAsync(int id)
        {
            return await _compraRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Compra>> ListAsync()
        {
            return await _compraRepository.ListAsync();
        }
    }
}