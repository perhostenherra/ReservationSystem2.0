using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public interface IReservationService
    {
        public Task CreateReservationAsync(Reservation res);
    }
}
