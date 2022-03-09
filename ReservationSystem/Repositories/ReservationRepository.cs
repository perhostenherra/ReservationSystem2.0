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
    }
}
