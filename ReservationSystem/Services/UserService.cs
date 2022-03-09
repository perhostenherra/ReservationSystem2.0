using ReservationSystem.Models;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserDTO> CreateUserAsync(User user)
        {
            User newUser = await _repository.AddUserAsync(user);
            return UserToDTO(newUser);
        }

       
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            List<User> list = (await _repository.GetAllUsersAsync()).ToList();
            List<UserDTO> dtoList = new List<UserDTO>();
            foreach(User u in list){
                dtoList.Add(UserToDTO(u));

            }
            return dtoList;
        }

        private User DTOToUser(UserDTO user, String password)
        {
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Password = password;

            return newUser;
        }

        private UserDTO UserToDTO(User user)
        {
            UserDTO dto = new UserDTO();
            dto.Id = user.Id;
            dto.UserName = user.UserName;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;

            return dto;
        }

    }
}
