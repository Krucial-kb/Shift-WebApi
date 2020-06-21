using Shift_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Posts>> GetPostsAsync();
        Task<Posts> GetPostByID(int postID);
        Task<Posts> CreatePost(Posts post);
        Task<Posts> UpdatePost(Posts post);
        Task<Posts> RemovePost(int postID);
        Task<Posts> Save();
    }
}
