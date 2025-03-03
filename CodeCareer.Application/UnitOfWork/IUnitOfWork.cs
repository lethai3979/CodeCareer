using CodeCareer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IApplierDetailRepository ApplierDetailRepository { get; }
        Task SaveChangeAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
