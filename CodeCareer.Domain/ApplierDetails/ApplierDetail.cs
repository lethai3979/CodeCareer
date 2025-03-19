using CodeCareer.Posts;
using CodeCareer.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.ApplierDetails
{
    public class ApplierDetail : BaseEntity
    {
        public ApplierDetail(Guid id, string applierId, Guid postId)
            : base(id)
        {
            Id = id;
            ApplierId = applierId;
            PostId = postId;
        }

        public string ApplierId { get; private set; }
        public Guid PostId { get; private set; }

        public bool IsApplied { get; private set; }

        public DateTime AppliedDate { get; private set; }
    }
}
