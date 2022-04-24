using Microsoft.AspNetCore.Mvc;
using ShiftDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftDomain.Interfaces
{
    public interface IUsersContract
    {
        //Get All (Show All Records)
        Task<IEnumerable<Users>> GetAllAsync();
        //Find By Id (Search)
        Task<Users> GetByIdAsync(int id);
        //POST Call (Create)
        void PostUserAsync(Users user);
        //PUT Call (Update)
        Task<bool> UpdateAsync(Users updateUser, int id);
        //DELETE Call (Remove specified record)
        void DeleteUser(Users user);
        //Persists to Database
        Task<int> SaveChangesAsync();
        //From Db to Client (List)
        Task<IEnumerable<Users>> ToListAsync();
    }
}
