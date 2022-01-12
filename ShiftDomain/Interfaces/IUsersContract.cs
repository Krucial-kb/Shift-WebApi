using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftDomain.DomainModels;

namespace ShiftDomain.Interfaces
{
    public interface IUsersContract
    {
        //GET ALL
        Task<IEnumerable<UsersModel>> GetAllAsync();
        //GET (ID) ASYNC
        Task<UsersModel> GetByIDAsync(int UserID);
        //POST CALL
        void PostUserAsync(UsersModel newUser);
        //PUT CALL
        Task<bool> UpdateAsync(UsersModel updateUser, int id);
        //DELETE CALL
        void DeleteUser(UsersModel player);
        //Persists to Database
        Task<int> SaveChangesAsync();
        //From Db to Client (List)
        Task<IEnumerable<UsersModel>> ToListAsync();
    }
}
