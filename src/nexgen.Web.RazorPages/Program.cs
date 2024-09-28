using FluentValidation;
using nexgen.Application;
using nexgen.Application.Mapper;
using nexgen.Application.Requests;
using nexgen.Application.Validators;
using nexgen.Domain.Factories;
using nexgen.Domain.Factories.Interfaces;
using nexgen.Infrastructure;
using nexgen.Shared.Config;
using nexgen.Shared.JwtHelper;
using Serilog;

namespace nexgen.Web.RazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false)
                            .Build();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddCors();
            builder.Services.AddAutoMapper(typeof(AppMapperProfile));
            builder.Services.AddMediatr();
            builder.Services.AddScoped<IBookFactory, BookFactory>();
            builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();
            builder.Services.AddScoped<IValidator<AuthUserRequest>, AuthUserRequestValidator>();
            builder.Services.AddScoped<JwtTokensUtility>();
            builder.Services.AddDbServices();
            builder.AddSerilogConfig(config);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSerilogRequestLogging();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
