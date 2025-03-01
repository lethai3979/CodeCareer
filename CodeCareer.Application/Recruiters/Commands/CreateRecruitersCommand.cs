using Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeCareer.Application.Recruiters.Commands
{

        public record CreateRecruitersCommand(String Name, String Email, String Password) : ICommand;  
}
