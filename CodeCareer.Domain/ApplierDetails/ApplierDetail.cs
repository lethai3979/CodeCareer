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
        public ApplierDetail(ApplierDetailId id, string applierId, string applierName, int postId, string postName)
            : base(id)
        {
            Id = id;
            ApplierId = applierId;
            ApplierName = applierName;
            PostId = postId;
            PostName = postName;
        }

        public string ApplierId { get; private set; }
        public string ApplierName { get; private set; }
        public int PostId { get; private set; }
        public string PostName { get; private set; }

        public bool IsApplied { get; private set; }

        public DateTime AppliedDate { get; private set; }
    }
}
