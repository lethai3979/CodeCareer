using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository UserRepository { get; }

        public IPostRepository PostRepository { get; }

        public IApplierDetailRepository PostDetailRepository { get; }

        public UnitOfWork(ApplicationDbContext context, 
                        IUserRepository userRepository, 
                        IPostRepository postRepository, 
                        IApplierDetailRepository postDetailRepository)
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
            PostDetailRepository = postDetailRepository;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            var trasation = await _context.Database.BeginTransactionAsync();
            return trasation;
        }
    }
}
