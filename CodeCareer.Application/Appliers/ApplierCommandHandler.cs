using Application.Abstraction.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Appliers
{
    internal class ApplierCommandHandler : ICommandHandler<ApplierCommand>
    {
        public Task Handle(ApplierCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
