﻿using nexgen.Infrastructure.Dapper;
using nexgen.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexgen.Infrastructure.Repositories.Interfaces;

namespace nexgen.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            services.AddScoped<IBookDbService, BookDbService>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IUserDbService, UserDbService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICoursesDbService, CoursesDbService>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();

            return services;
        }
    }
}
