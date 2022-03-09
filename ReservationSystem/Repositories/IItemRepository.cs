using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories
{
    public interface IItemRepository
    {
        public Task<Item> AddItemAsync(Item item);
        public Task<IEnumerable<Item>> GetAllItems();
    }
}
