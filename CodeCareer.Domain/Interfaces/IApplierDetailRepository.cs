using CodeCareer.ApplierDetails;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Interfaces
{
    public interface IApplierDetailRepository
    {
        Task<List<ApplierDetail>> GetAll();
        Task Add(ApplierDetail applierDetail);
        Task Delete(ApplierDetail applierDetail);
        Task<ApplierDetail> GetByUserId(string id);
        Task<ApplierDetail> GetByPostId(Post id);
    }
}
