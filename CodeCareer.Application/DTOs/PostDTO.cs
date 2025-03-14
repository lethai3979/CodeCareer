using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.DTOs
{
    public sealed class PostDTO
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public RecruiterDTO Recruiter { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
