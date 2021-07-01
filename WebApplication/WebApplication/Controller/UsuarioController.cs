using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Services;
using WebApplication.Extensions;
using WebApplication.Resource;

namespace WebApplication.Controller
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/usuarios")]
    [Authorize]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResource>>(usuarios);
            return Ok(resource);
        }

        
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var usuario = await _usuarioService.FindByIdAsync(id);
            if (usuario == null) return NoContent();
            var resource = _mapper.Map<Usuario, UsuarioResource>(usuario);
            return Ok(resource);
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);
            var result = await _usuarioService.SaveAsync(usuario);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<Usuario, UsuarioResource>(usuario);
            
            return Ok(userResource);

        }
        
        
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);
            var result = await _usuarioService.UpdateAsync(id, usuario);

            if (!result.Success)
                return BadRequest();

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Usuario);
            
            return Ok(usuarioResource);
        }

        
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            var result = await _usuarioService.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Usuario, UsuarioResource>(result.Usuario);

            return Ok(resource);
        }
    }
}