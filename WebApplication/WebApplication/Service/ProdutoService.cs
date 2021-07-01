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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<ProdutoResponse> SaveAsync(Produto produto)
        {
            try
            {
                await _produtoRepository.AddAsync(produto);
                await _unitOfWork.CompleteAsync();
                return new ProdutoResponse(produto);

            }
            catch (Exception e)
            {
                return new ProdutoResponse($"An error occurred {e.Message}");
            }
            
        }

        public async Task<ProdutoResponse> UpdateAsync(int id, Produto produto)
        {
            try
            {
                var _produto = await _produtoRepository.FindByIdAsync(id);
                
                if (_produto == null) return new ProdutoResponse($"this product doesn't exists {id}");

                _produto.Nome = produto.Nome;
                _produto.Valor = produto.Valor;
                _produto.Observacao = produto.Observacao;
                
                _produtoRepository.Update(_produto);
                await _unitOfWork.CompleteAsync();

                return new ProdutoResponse(_produto);

            }
            catch (Exception e)
            {
                return new ProdutoResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<ProdutoResponse> DeleteAsync(int id)
        {
            try
            {
                var produto = await _produtoRepository.FindByIdAsync(id);

                if (produto == null) return new ProdutoResponse($"this product doesn't exists by {id}");
                
                _produtoRepository.Remove(produto);
                await _unitOfWork.CompleteAsync();
                return new ProdutoResponse(produto);
                
            }
            catch (Exception e)
            {
                return new ProdutoResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _produtoRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListAsync()
        {
            return await _produtoRepository.ListAsync();
        }
    }
}