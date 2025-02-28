using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCareer.Domain.Interfaces;

namespace CodeCareer.Domain.Posts
{
    public interface IPostRepository : IPostRepository<Post, PostId>
    {
    }
}
