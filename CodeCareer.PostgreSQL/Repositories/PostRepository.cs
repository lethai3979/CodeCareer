using CodeCareer.Domain.Interfaces;
using CodeCareer.Posts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Repository
{
    internal class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post entity)
        {
            await _context.Posts.AddAsync(entity);
        }

        public void Delete(Post entity)
        {

            _context.Posts.Remove(entity);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Post?> GetById(PostId id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Post entity)
        {
            _context.Posts.Update(entity);

        }

    }
}
