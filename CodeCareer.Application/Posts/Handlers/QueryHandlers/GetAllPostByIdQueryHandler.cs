using Application.Abstraction.Queries;
using AutoMapper;
using CodeCareer.Application.DTOs;
using CodeCareer.Application.Posts.Queries;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers.QueryHandlers
{
    internal class GetAllPostByIdQueryHandler : IQueryHandler<GetAllPostByIdQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllPostByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(GetAllPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetAllById(request.Id);
            var postDTOs = _mapper.Map<List<PostDTO>>(post);
            return Result<List<PostDTO>>.SuccessResult(postDTOs);
        }
    }
}
