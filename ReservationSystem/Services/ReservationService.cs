using ReservationSystem.Models;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        public ReservationService(IReservationRepository repository) 
        {
            _repository = repository;
        }
        public async Task CreateReservationAsync(Reservation res)
        {
            //Lisää varaus
            //Tarkista ensin onko kohde vapaa halutulla ajalla
           
            await _repository.AddReservationAsync(res);
            
        }
    }
}
