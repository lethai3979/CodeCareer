using CodeCareer.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.DTOs
{
    public sealed class PostDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string RecruiterUserName { get; set; } = null!;
        public string RecruiterAddress { get; set; } = null!;
        public string RecruiterDescription { get; set; } = null!;
        public DateTime PublishDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
    }
}
