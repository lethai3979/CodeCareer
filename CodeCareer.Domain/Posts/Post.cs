using CodeCareer.ApplierDetails;
using CodeCareer.Primitives;
using CodeCareer.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Posts
{
    public class Post :  BaseEntity<PostId>
    {
        public Post(PostId id,
            string title,
            string description,
            string recruiterId,
           
            DateTime publishDate,
            DateTime expireDate
            ) : base(id)
        {
            Id = id;
            Title = title;
            Description = description;
            RecruiterId = recruiterId;
           
            PublishDate = publishDate;
            ExpireDate = expireDate;
           
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string RecruiterId { get; private set; }
        public Recruiter Recruiter { get; private set; } = null!;
        public DateTime PublishDate { get; private set; }
        public DateTime ExpireDate{ get; private set; }
        public bool IsDeleted { get; private set; }
        public List<ApplierDetail> ApplierDetails { get; private set; } = new List<ApplierDetail>();
    }
}
