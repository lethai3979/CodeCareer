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
    public class Post :  BaseEntity
    {
        public Post(Guid id,
            string title,
            string description,
            string imageUrl,
            string recruiterId,
            DateTime expireDate
            ) : base(id)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            RecruiterId = recruiterId;     
            PublishDate = DateTime.Now;
            ExpireDate = expireDate;
           
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string RecruiterId { get; private set; }
        public Recruiter Recruiter { get; private set; } = null!;
        public DateTime PublishDate { get; private set; }
        public DateTime ExpireDate{ get; private set; }
        public bool IsDeleted { get; private set; }
        public List<ApplierDetail> ApplierDetails { get; private set; } = new List<ApplierDetail>();

        public void Update(string title, string? description, DateTime expireDate)
        {
            Title = title;
            if(description != null)
            {
                Description = description;
            }    
            ExpireDate = expireDate;
        }
        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
