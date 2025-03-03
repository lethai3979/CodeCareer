using CodeCareer.Posts;
using CodeCareer.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.ApplierDetails
{
    public class ApplierDetail : BaseEntity<ApplierDetailId>
    {
        public ApplierDetail(ApplierDetailId id, string applierId, PostId postId)
            : base(id)
        {
            Id = id;
            ApplierId = applierId;
            PostId = postId;
        }

        public string ApplierId { get; private set; }
        public PostId PostId { get; private set; }

        public bool IsApplied { get; private set; }

        public DateTime AppliedDate { get; private set; }
    }
}
