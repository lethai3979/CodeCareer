using Application.Abstraction.Queries;
using CodeCareer.Application.Posts.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers
{
    public class GetAllPostsQueryHandler : IQueryHandler<GetAllPostQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetAll();
            return Result<List<Post>>.SuccessResult(post);
        }
    }
}
