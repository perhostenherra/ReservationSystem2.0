using ReservationSystem.Models;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services
{
    public class ItemService : IItemService 
    {
        private readonly IItemRepository _repository;
        private readonly IUserRepository _userRepository;
        public ItemService(IItemRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }
        public async Task<ItemDTO> CreateItemAsync(ItemDTO item)
        {
            Item newItem = await DTOToItem(item);

            if (newItem == null)
            {
                return null;
            }

            newItem = await _repository.AddItemAsync(newItem);

            if (newItem.Id != 0)
            {
                return ItemToDTO(newItem);
            }
            else
            {
                return null;
            }
        }

        private async Task<Item> DTOToItem(ItemDTO dto)
        {

            User owner = await _userRepository.GetUserAsync(dto.Owner);
            if (owner == null)
            {
                return null;
            }

            Item item = new Item();
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.Image = dto.Image;
            item.Owner = owner;

            return item;
        }

        private ItemDTO ItemToDTO(Item item)
        {

            ItemDTO dto = new ItemDTO();
            dto.Id = item.Id;
            dto.Name = item.Name;
            dto.Description = item.Description;
            dto.Image = item.Image;
            dto.Owner = item.Owner.UserName;

            return dto;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItems()
        {
            IEnumerable<Item> items = await _repository.GetAllItems();
            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            foreach (Item i in items)
            {
                itemDTOs.Add(ItemToDTO(i));
            }
            return itemDTOs;
        }

        public Task<Item> CreateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
   

