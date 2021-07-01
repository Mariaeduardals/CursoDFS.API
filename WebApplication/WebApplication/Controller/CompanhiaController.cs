using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Services;
using WebApplication.Resource;
using  WebApplication.Extensions;

namespace WebApplication.Controller
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/companhias")]
    [Authorize]
    public class CompanhiaController : ControllerBase
    {
        private readonly ICompanhiaService _companhiaServices;
        private readonly IMapper _mapper;
       
        public CompanhiaController(ICompanhiaService companhiaServices, IMapper mapper)
        { 
          _companhiaServices = companhiaServices;
          _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async  Task<IActionResult> GetAllAsync()
        {
            var companhias = await _companhiaServices.ListAsync();
            var resources = _mapper.Map<IEnumerable<Companhia>, IEnumerable<CompanhiaResource>>(companhias);
            
            return Ok(resources);
        }
        
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var companhia = await _companhiaServices.FindByIdAsync(id);
            if (companhia == null) return NoContent();
            var resource = _mapper.Map<Companhia, CompanhiaResource>(companhia);
            return Ok(resource);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanhiaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var companhia = _mapper.Map<SaveCompanhiaResource, Companhia>(resource);
            var result = await _companhiaServices.SaveAsync(companhia);

            if (!result.Success)
                return BadRequest(result.Message);

            var companhiaResource = _mapper.Map<Companhia, CompanhiaResource>(result.Companhia);

            return Ok(companhiaResource);

        }
        
        [HttpPut("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanhiaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var companhia = _mapper.Map<SaveCompanhiaResource, Companhia>(resource);
            var result = await _companhiaServices.UpdateAsync(id, companhia);

            if (!result.Success)
                return BadRequest(result.Message);

            var companhiaResource = _mapper.Map<Companhia, CompanhiaResource>(result.Companhia);
            return Ok(companhiaResource);
        }
        
         [HttpDelete("{id:int}")]
         [AllowAnonymous]
                public async Task<IActionResult> DeleteAsync(int id)
                {
                    var result = await _companhiaServices.DeleteAsync(id);
        
                    if (!result.Success)
                        return BadRequest(result.Message);
        
                    var companhiaResource = _mapper.Map<Companhia, CompanhiaResource>(result.Companhia);
                    return Ok(companhiaResource);
                }


}
}