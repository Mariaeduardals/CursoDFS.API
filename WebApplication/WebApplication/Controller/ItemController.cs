using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Services;
using WebApplication.Resource;

namespace WebApplication.Controller
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/items")]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var items = await _itemService.FindCompraIdAsync(id);
            var resource = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);
            return Ok(resource);
        }

    }
}