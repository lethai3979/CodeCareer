﻿using CodeCareer.Application.Recruiters.Commands;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using CodeCareer.Recruiters;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Recruiters.Handlers
{
    public class CreateRecruitersHandler : IRequestHandler<CreateRecruitersCommand>
    {
       

        private readonly IUnitOfWork _unitOfWork;
        public  CreateRecruitersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateRecruitersCommand request, CancellationToken cancellationToken)
        {
            var recruiter = new Recruiter(request.Name, request.Email);
            recruiter.UserName = request.Email;
            recruiter.Email = request.Email;
            var result = await _unitOfWork.UserRepository.Create(recruiter, request.Password);
        }
    }
}
