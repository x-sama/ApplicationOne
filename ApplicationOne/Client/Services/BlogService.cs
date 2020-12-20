using ApplicationOne.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApplicationOne.Client.Services
{
    public class BlogService : IBlogServices
    {
        private readonly HttpClient _http;

        public BlogService(HttpClient http)
        {
            _http = http;
        }
    public async Task<List<Post>> GetAllPosts()
        {
            return await _http.GetFromJsonAsync<List<Post>>("/api/Blog");
           
        }

        public async Task<Post> GetPost(string url)
        {
            var result = await _http.GetAsync($"/api/Blog/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //we said in the api that if there is no post in db we return a message NotFount  TYPE
                // now we have to read it here and retur it to the view
                var message = await result.Content.ReadAsStringAsync(); // wait the error message from the api
                Console.WriteLine(message); // console it
                return new Post { Title = message }; // return a post with a title error
            }
            else
            {
                //here if we found a post we return it
                 var post = await _http.GetFromJsonAsync<Post>($"/api/Blog/{url}");
                 return post;
            }

        }

        public async Task<Post> PostBlogToDatabase(Post post)
        {
            var result = await _http.PostAsJsonAsync<Post>($"/api/Blog", post);

            return await result.Content.ReadFromJsonAsync<Post>();

        }

       
    }
}
