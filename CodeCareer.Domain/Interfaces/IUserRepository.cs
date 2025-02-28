using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Create(IdentityUser user, string password);
        Task<IdentityResult> SetUserRole(IdentityUser user, string role);
        Task<IdentityUser?> FindById(string id);
        Task<IdentityUser?> FindByEmail(string email);
        Task<bool> CheckPassword(IdentityUser user, string password);
        Task<List<IdentityUser>> GetAll();
        Task<IList<string>> GetAllUserRoles(IdentityUser user);
    }
}
