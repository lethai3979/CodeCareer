using CodeCareer.Domain.Interfaces;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Repository
{
    internal class PostRepository : IPostRepository
    {
        public Task Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetById(PostId id)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
