using System;
using System.Collections.Generic;

namespace Shift_Blazor.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostDetails = new HashSet<PostDetails>();
        }

        public int PostId { get; set; }
        public string Title { get; set; }
        public byte[] Media { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<PostDetails> PostDetails { get; set; }
    }
}
