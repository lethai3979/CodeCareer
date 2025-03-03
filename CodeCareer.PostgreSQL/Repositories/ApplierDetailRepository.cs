using CodeCareer.ApplierDetails;
using CodeCareer.Domain.Interfaces;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Repository
{
    public class ApplierDetailRepository : IApplierDetailRepository
    {
        public Task Add(ApplierDetail applierDetail)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ApplierDetail applierDetail)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplierDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApplierDetail> GetByPostId(Post id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplierDetail> GetByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
