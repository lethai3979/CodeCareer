using CodeCareer.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Create(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);

        }

        public async Task<IdentityResult> Delete(IdentityUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityUser?> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<IdentityUser?> FindById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<List<IdentityUser>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<bool> CheckPassword(IdentityUser user, string password)
        {
            var isCorrect = await _userManager.CheckPasswordAsync(user, password);
            return isCorrect;
        }

        public async Task<IdentityResult> Update(IdentityUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> SetUserRole(IdentityUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IList<string>> GetAllUserRoles(IdentityUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
