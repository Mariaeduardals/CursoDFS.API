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
    [Route("/api/compras")]
    [Authorize]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public CompraController(ICompraService compraService, IMapper mapper)
        {
            _compraService = compraService;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var compras = await _compraService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Compra>, IEnumerable<CompraResource>>(compras);
            return Ok(resource);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var compra = await _compraService.FindByIdAsync(id);
            if (compra == null) return NoContent();

            var resource = _mapper.Map<Compra, CompraResource>(compra);

            return Ok(resource);
        }


        [HttpPost]
        
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompraResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var compra = _mapper.Map<SaveCompraResource, Compra>(resource);

            var result = await _compraService.SaveAsync(compra);

            if (!result.Success)
                return BadRequest();

            var purchaseResource = _mapper.Map<Compra, CompraResource>(result.Compra);
            return Ok(purchaseResource);

        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompraResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var compra = _mapper.Map<SaveCompraResource, Compra>(resource);
            var result = await _compraService.UpdateAsync(id, compra);

            if (!result.Success)
                return BadRequest();

            var purchaseResource = _mapper.Map<Compra, CompraResource>(result.Compra);
            return Ok(purchaseResource);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _compraService.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Compra, CompraResource>(result.Compra);
            return Ok(resource);
        }
    }
}