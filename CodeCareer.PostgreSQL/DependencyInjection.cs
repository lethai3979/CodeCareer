using CloudinaryDotNet;
using CodeCareer.Application.Abstraction;
using CodeCareer.Application.Authentication;
using CodeCareer.Application.UnitOfWork;
using CodeCareer.Domain.Interfaces;
using CodeCareer.PostgreSQL.Authentication;
using CodeCareer.PostgreSQL.File;
using CodeCareer.PostgreSQL.Repository;
using CodeCareer.PostgreSQL.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL
{
    public static class DependencyInjection
    {
        public static void AddPostgreSQL(this IServiceCollection services, string connectionString) 
        {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IApplierDetailRepository, ApplierDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJWTProvider, JWTProvider>();
            services.AddScoped<ICloudService, CloudService>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped<RoleManager<IdentityRole>>();
        }
    }
}
