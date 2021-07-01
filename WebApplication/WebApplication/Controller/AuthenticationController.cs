using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Services;
using WebApplication.Extensions;
using WebApplication.Resource;
using WebApplication.Util;

namespace WebApplication.Controller
{
    [AllowAnonymous]
    [Route("/api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUsuarioService usuarioService, IMapper mapper, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _configuration = configuration;

        }

        [HttpPost]
        public async Task<IActionResult> LoginCredentials([FromBody] AuthUsuarioResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var usuario = _mapper.Map<AuthUsuarioResource, Usuario>(resource);
                var result = await _usuarioService.FirstOrDefaultAsync(usuario.Email, usuario.Password);

                if (result == null)
                    return Unauthorized();

                var token = CryptoFunction.GenerateToken(_configuration, usuario);
                return Ok(new
                {
                    error = false,
                    result = new
                    {
                        token, user = new {usuario.Id, usuario.Email}
                    }
                });
            }
            catch (Exception e)
            {
                var message = $"An error occurred in auth service {e.Message}";
                return BadRequest(new {error = true, result = new {message}});
            }
        }
    }
}