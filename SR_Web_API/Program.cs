using Microsoft.EntityFrameworkCore;
using SR_WebAPI_Application.Interfaces;
using SR_WebAPI_Application.Services;
using SR_WebAPI_Domain.Interfaces;
using SR_WebAPI_Infrastructure.Context;
using SR_WebAPI_Infrastructure.Repositories;

namespace SR_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IStudentReporitory, StudentRepository>();

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDBContext>(
                options => options.UseSqlServer(connString, x => x.MigrationsAssembly("SR_WebAPI")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowOrigin"); // Apply CORS middleware

            app.MapControllers();

            app.Run();
        }
    }
}