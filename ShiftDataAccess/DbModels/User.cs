using System;
using System.Collections.Generic;

#nullable disable

namespace ShiftDataAccess.DbModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
