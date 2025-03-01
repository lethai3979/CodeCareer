using CodeCareer.Application.Posts.Commands;
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
    public class CreatePostHandler : IRequestHandler<CreatePostCommands>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePostCommands request, CancellationToken cancellationToken)
        {
            var lengthPost = await _unitOfWork.PostRepository.GetAll();
            var post = new Post(new PostId(lengthPost.Count+1), request.title, request.RecruiterId, request.description, request.publishDate, request.expireDate);
            await _unitOfWork.PostRepository.Add(post);
        }
    }
    

}
