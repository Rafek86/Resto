using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services
{
  public interface IMenuService 
    {
        Task<string> AddMenuItemAsync(string name, string description, decimal price, string category);
        Task<string> UpdateMenuItemAsync(string id, string name, string description, decimal price, string category);
        Task<bool> DeleteMenuItemAsync(string id);
        Task<IEnumerable<MenuDto>> GetAllMenuItemsAsync();
        Task<MenuDto> GetMenuItemByIdAsync(string id);
        Task<IEnumerable<MenuDto>> GetMenuItemsByCategoryAsync(string category);
    }
}
