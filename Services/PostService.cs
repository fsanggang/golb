using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Golb.Data;

namespace Golb.Services
{
    public interface IPostService
    {
        Task<Post[]> Get();
        Task<Post> Create(Post post);
    }
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Post[]> Get()
        {
            return await _context.Posts.ToArrayAsync();
        }

        public async Task<Post> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
