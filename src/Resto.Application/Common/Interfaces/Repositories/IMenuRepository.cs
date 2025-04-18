using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
  public interface IMenuRepository
    {
        Task<string> AddMenuItemAsync(string name, string description, decimal price, string category);
        Task<string> UpdateMenuItemAsync(int id, string name, string description, decimal price, string category);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
    }
}
