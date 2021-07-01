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
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
       private readonly IUnitOfWork _unitOfWork;
        
        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UsuarioResponse> SaveAsync(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.AddAsync(usuario);
                await _unitOfWork.CompleteAsync();
                return new UsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario)
        {
            try
            {
                var _usuario = await _usuarioRepository.FindByIdAsync(id);

                if (_usuario == null) return new UsuarioResponse($"this user not found by id {id}");

                _usuario.Nome = usuario.Nome;
                _usuario.Email = usuario.Email;
                _usuario.Cpf = usuario.Cpf;
                _usuario.Password = usuario.Password;
                _usuario.Compra = usuario.Compra;
                _usuarioRepository.Update(_usuario);
                await _unitOfWork.CompleteAsync();
                return new UsuarioResponse(_usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occurred {e.Message}");
            }
            
        }

        public async Task<UsuarioResponse> DeleteAsync(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.FindByIdAsync(id);
                if (usuario == null) return new UsuarioResponse($"this user doesn't exists by id {id}");
                
                _usuarioRepository.Remove(usuario);
                await _unitOfWork.CompleteAsync();
                return new UsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new UsuarioResponse($"An error occured {e.Message}");
            }
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _usuarioRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _usuarioRepository.ListAsync();
        }
        
        public async Task<Usuario> FirstOrDefaultAsync(string email, string password)
        {
            return await _usuarioRepository.FirstOrDefaultAsync(email, password);
        }
    }
}