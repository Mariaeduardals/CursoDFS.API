using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Dominio.Modelos;
using WebApplication.Dominio.Repositories;
using WebApplication.Dominio.Services;

namespace WebApplication.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            
        }
        public async Task<IEnumerable<Item>> FindCompraIdAsync(int id)
        {
            return await _itemRepository.FindCompraIdAsync(id);
        }
    }
}