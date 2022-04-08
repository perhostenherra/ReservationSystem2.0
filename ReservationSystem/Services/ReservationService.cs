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
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;
        public ReservationService(IReservationRepository repository, IUserRepository userRepository, IItemRepository itemRepository) 
        {
            _repository = repository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;

        }
        public async Task CreateReservationAsync(Reservation res)
        {
            //Lisää varaus
            //Tarkista ensin onko kohde vapaa halutulla ajalla
           
            await _repository.AddReservationAsync(res);
            
        }

        public Task CreateReservationAsync(ReservationDTO res)
        {
            throw new NotImplementedException();
        }

        public Task CreateReservationAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationDTO>> GetAllReservations()
        {
            IEnumerable<Reservation> reservation = await _repository.GetReservationAsync();
            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
            foreach(Reservation r in Reservations)
            {
                reservationDTOs.Add(ReservationToDTO(r));
            }
            return reservationDTOs;
        }

        public Task<IEnumerable<ReservationDTO>> GetAllReservationsForUser(string Username)
        {
            User owner = await _userRepository.GetUserAsync(username);
            if(owner == null)
            {
                return null;
            }
        }
        IEnumerable<Reservation> ReservationService = await _repository.GetReservationAsync(owner);
        List<ReservationDTO> dTOs = new List<ReservationDTO>();
        foreach(Reservation r in reservations)
            {
            dTOs.Add(ReservationToDTO(r));
            }
    return dTOs;

        Task<ReservationDTO> IReservationService.CreateReservationAsync(ReservationDTO res)
        {
            //lisää varaus
            Reservation newReservation = await DTOToReservationAsync(res);

            await _repository.AddReservationAsync(newReservation);
            return ReservationDTO(newReservation);
        }

        Task<ReservationDTO> IReservationService.CreateReservationAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
