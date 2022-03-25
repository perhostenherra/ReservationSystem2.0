using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            var user = await _reservationContext.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            byte[] salt = user.salt;
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: password, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));

            if(hashedPassword != user.Password)
            {
                return null;
            }

            return user;
        }
    }
}
