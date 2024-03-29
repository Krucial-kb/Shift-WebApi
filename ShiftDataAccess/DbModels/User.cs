﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ShiftDataAccess.DbModels
{
    public partial class User
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }


        public string LastName { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string UserName { get; set; }

        [DataType(DataType.ImageUrl)]
        public byte[] ProfilePicture { get; set; }
    }
}
