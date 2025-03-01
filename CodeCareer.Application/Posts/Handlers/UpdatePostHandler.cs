using Application.Abstraction.Commands;
using CodeCareer.Application.Posts.Commands;
using CodeCareer.Application.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Posts.Handlers
{
    public class UpdatePostHandler: IRequestHandler<UpdatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var 
        }
    }
}
