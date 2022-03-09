using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories
{
   public interface IUserRepository
    {
        public Task<User> AddUserAsync(User user);
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
