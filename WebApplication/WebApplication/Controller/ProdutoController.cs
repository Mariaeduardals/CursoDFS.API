using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Communication;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Services;
using WebApplication.Extensions;
using WebApplication.Resource;

namespace WebApplication.Controller
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/produtos")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var produtos = await _produtoService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoResource>>(produtos);
            
            return Ok(resource);
        }

        
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var produto = await _produtoService.FindByIdAsync(id);
            if (produto == null) return NoContent();
            var resource = _mapper.Map<Produto, ProdutoResource>(produto);
            return Ok(resource);
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveProdutoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var produtos = _mapper.Map<SaveProdutoResource, Produto>(resource);
            
            var result = await _produtoService.SaveAsync(produtos);

            if (!result.Success)
                return BadRequest();

            var produtoResponse = _mapper.Map<Produto, ProdutoResponse>(result.Produto);
            return Ok(produtoResponse);

        }
        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProdutoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var produto = _mapper.Map<SaveProdutoResource, Produto>(resource);
            var result = await _produtoService.UpdateAsync(id, produto);

            if (!result.Success)
                return BadRequest();

            var produtoResource = _mapper.Map<Produto, ProdutoResource>(result.Produto);
            return Ok(produtoResource);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _produtoService.DeleteAsync(id);
            
            if (!result.Success)
                return NotFound();
            
            var resource = _mapper.Map<Produto, ProdutoResource>(result.Produto);
            return Ok(resource);
        } 
    }
}