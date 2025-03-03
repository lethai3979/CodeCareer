using CodeCareer.ApplierDetails;
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
    public class ApplierDetailRepository : IApplierDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplierDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ApplierDetail applierDetail)
        {
            await _context.AddAsync(applierDetail);
        }

        public void Delete(ApplierDetail applierDetail)
        {
            _context.Remove(applierDetail);
        }

        public Task<List<ApplierDetail>> GetAll()
        {
            return _context.ApplierDetails.ToListAsync();
        }

        public Task<ApplierDetail?> GetByPostId(PostId id)
        {
            return _context.ApplierDetails.FirstOrDefaultAsync(a => a.PostId == id);
        }

        public Task<ApplierDetail?> GetByUserId(string id)
        {
            return _context.ApplierDetails.FirstOrDefaultAsync(a => a.ApplierId == id);
        }
    }
}
