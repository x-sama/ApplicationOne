using ApplicationOne.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationOne.Client.Services
{
    interface IBlogServices
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPost(string Url);
        Task<Post> PostBlogToDatabase(Post post);


    }
}
