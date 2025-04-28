
using BookManager.BLL.Interfaces;
using BookManager.BLL.Services;
using BookManager.DAL.Interfaces;
using BookManager.DAL.Repositories;
using BookManager.DB;
using Microsoft.EntityFrameworkCore;

namespace BookManager.API
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

            builder.Services.AddScoped<ILivreService, LivreService>();
            builder.Services.AddScoped<ILivreRepository, LivreRepository>();

            builder.Services.AddDbContext<BookManagerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

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
