using Application.Handler.QueryHandler;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;  // Add this using directive
using MediatR;
using FluentValidation.AspNetCore;
using Application.Validators;
using FluentValidation.AspNetCore;
namespace DemoEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetAllTeachersHandler).Assembly));
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ITeacherRepository , TeacherRepository>();

            builder.Services.AddScoped<ITeacherService, TeacherService>();


            // Add services to the container.
            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(CreateTeacherDTOValidator).Assembly));


            //mediatr
            // Register MediatR


            // Add DbContext with SQL Server connection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
