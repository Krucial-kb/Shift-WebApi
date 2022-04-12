using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftDataAccess.DbModels;
using ShiftDomain.DomainModels;

namespace ShiftDataAccess.Mapper
{
    public class ShiftDataMapper
    {

        #region ----- Data Access(DB) to Domain(ViewModels) -----
        public static User MapDbToViewModel(ShiftDomain.DomainModels.Users _dbUsers)
        {
            return _dbUsers is null ? null : new ShiftDataAccess.DbModels.User
            { 
                Id = _dbUsers.Id,
                FirstName = _dbUsers.FirstName,
                LastName = _dbUsers.LastName,
                UserName = _dbUsers.UserName,
                Email = _dbUsers.Email,
                Password = _dbUsers.Password,
                ProfilePicture = _dbUsers.ProfilePicture,
            };   
        }
        #endregion

        #region ----- Domain(ViewModels) to Data Access(DB) -----
        public static Users MapViewModelToDb(ShiftDataAccess.DbModels.User _daUsers)
        {

            return _daUsers is null ? null : new ShiftDomain.DomainModels.Users
            {
                Id= _daUsers.Id,
                UserName = _daUsers.UserName,
                FirstName = _daUsers.FirstName,
                LastName= _daUsers.LastName,
                Email = _daUsers.Email,
                ProfilePicture = _daUsers.ProfilePicture,
                Password = _daUsers.Password,
            };
        }
        #endregion
    }
}
