using CodeCareer.Application.Posts.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPostQuery, IEnumerable<Post>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPostsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PostRepository.GetAll();
        }
    }
}
