using CodeCareer.Posts;
using CodeCareer.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Post?> GetById(PostId id);
        Task<List<Post>> GetAll();
        Task Add(Post entity);
        void Update(Post entity);
        void Delete(Post entity);

    }
}
