using ReservationSystem.Models;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Item> CreateItemAsync(Item item)
        {
           item = await _repository.AddItemAsync(item);

            if (item.Id != 0)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _repository.GetAllItems();
        }
    }
}
