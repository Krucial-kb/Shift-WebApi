using Shift_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();
        Task<Users> GetUserByID(int userID);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> RemoveUser(int userID);
        Task<Users> Save();
    }
}
