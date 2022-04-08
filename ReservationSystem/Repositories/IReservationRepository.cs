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
        public Task<Reservation> GetReservationAsync(long id);
        Task<Reservation> GetReservationAsync();
        Task<Reservation> GetReservationAsync(Item target, DateTime start, DateTime end);
        Task<Reservation> GetReservationAsync(User user);
    }
}
