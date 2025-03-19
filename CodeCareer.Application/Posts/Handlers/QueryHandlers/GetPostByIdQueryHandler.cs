using Application.Abstraction.Queries;
using AutoMapper;
using CodeCareer.Application.DTOs;
using CodeCareer.Application.Posts.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using CodeCareer.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers.QueryHandlers
{
    public sealed class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetById(new Guid(request.Id));
            if (post == null)
            {
                return Result.FailureResult(Error.NotFound("Post not found"));
            }
            var postDTO = _mapper.Map<PostDTO>(post);
            return Result<PostDTO>.SuccessResult(postDTO);
        }
    }
}
