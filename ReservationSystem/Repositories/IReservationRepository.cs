using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories
{
   public interface IReservationRepository
    {
        public Task<Reservation> AddReservationAsync(Reservation res);
    }
}
