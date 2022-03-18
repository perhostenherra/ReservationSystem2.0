using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Middleware
{
    public interface IUserAuthenticationService
    {
        Task<User> Authenticate(string username, string password);

            
    }
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly ReservationContext _reservationContext;

        public UserAuthenticationService(ReservationContext context)
        {
            _reservationContext = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _reservationContext.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
