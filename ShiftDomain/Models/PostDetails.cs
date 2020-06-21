using System;
using System.Collections.Generic;

namespace Shift_Blazor.Models
{
    public partial class PostDetails
    {
        public PostDetails()
        {
            Users = new HashSet<Users>();
        }

        public int DetailsId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? PostDate { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
