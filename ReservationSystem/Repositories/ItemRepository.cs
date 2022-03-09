using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ReservationContext _context;
        public ItemRepository(ReservationContext context)
        {
            _context = context;
        }
        public async Task<Item> AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            try
            {
               await _context.SaveChangesAsync();
            }
            catch(Exception)
            {

            }
            return item;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
