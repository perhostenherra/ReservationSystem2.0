using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ReservationContext _context;
        public UserRepository(ReservationContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
