using CodeCareer.Application.Authentication;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using CodeCareer.PostgreSQL.Authentication;
using CodeCareer.PostgreSQL.Repository;
using CodeCareer.PostgreSQL.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL
{
    public static class DependencyInjection
    {
        public static void AddPostgreSQL(this IServiceCollection services, string connectionString) 
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IApplierDetailRepository, ApplierDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJWTProvider, JWTProvider>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<RoleManager<IdentityRole>>();
        }
    }
}
