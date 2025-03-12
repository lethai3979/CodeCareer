using Application.Abstraction.Queries;
using AutoMapper;
using CodeCareer.Application.DTOs;
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
        private readonly IMapper _mapper;
        public GetAllPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetAll();
            var postDTOs = _mapper.Map<List<PostDTO>>(posts);
            return Result<List<PostDTO>>.SuccessResult(postDTOs);
        }
    }
}
