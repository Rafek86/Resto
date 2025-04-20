using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
    public class MenuService(IMenuRepository menuRepository) : IMenuRepository
    {
        private readonly IMenuRepository _menuRepository = menuRepository;

        public async Task<string> AddMenuItemAsync(string name, string description, decimal price, string category)
        {
         return  await  _menuRepository.AddMenuItemAsync(name, description, price, category);
        }


        public async Task<string> UpdateMenuItemAsync(string id, string name, string description, decimal price, string category)
        {
            return await _menuRepository.UpdateMenuItemAsync(id, name, description, price, category);
        }

        public async Task<bool> DeleteMenuItemAsync(string id)
        {
            return await _menuRepository.DeleteMenuItemAsync(id);
        }

        public async Task<IEnumerable<MenuDto>> GetAllMenuItemsAsync()
        {
            return await _menuRepository.GetAllMenuItemsAsync();
        }

        public async Task<MenuDto> GetMenuItemByIdAsync(string id)
        {
            return await _menuRepository.GetMenuItemByIdAsync(id);
        }

        public async Task<IEnumerable<MenuDto>> GetMenuItemsByCategoryAsync(string category)
        {
            return await _menuRepository.GetMenuItemsByCategoryAsync(category);
        }

    }
}
