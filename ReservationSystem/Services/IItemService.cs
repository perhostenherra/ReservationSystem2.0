using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public interface IItemService
    {
        public Task<Item> CreateItemAsync(ItemDTO item);
        public Task<IEnumerable<Item>> GetAllItems();
    }
}
