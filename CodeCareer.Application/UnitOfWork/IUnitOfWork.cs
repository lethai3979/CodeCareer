using CodeCareer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IPostDetailRepository PostDetailRepository { get; }

        Task SaveChangeAsync();
    }
}
