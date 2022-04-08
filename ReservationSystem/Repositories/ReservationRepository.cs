using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        public ReservationRepository(ReservationContext context) 
        {
            _context = context;
        }
        public async Task<Reservation> AddReservationAsync(Reservation res)
        {
            //Tallenna uusi varaus
            _context.Reservations.Add(res);
            try { 
            await _context.SaveChangesAsync();
            }
            catch(Exception)
            {

            }
            return res;


        }

        public Task<Reservation> GetReservationAsync(long id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public Task<Reservation> GetReservationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetReservationAsync(Item target, DateTime start, DateTime end)
        {
            return await _context.Reservations.Where(x => x.Target == target).ToListAsync();
        }

        public async Task<Reservation> GetReservationAsync(User user)
        {
            return await _context.Reservations.Where(x => x.Owner == user).ToListAsync();//kysy
        }
    }
}
