using System;
using System.Collections.Generic;

namespace ShiftWebApi
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[]? UserName { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
