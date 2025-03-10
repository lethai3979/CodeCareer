using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.DTOs
{
    public sealed class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public RecruiterDTO Recruiter { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
