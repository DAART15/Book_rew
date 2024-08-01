
using Book_rew.Database;
using Book_rew.Database.Data;
using Book_rew.Interfaces;
using Book_rew.Models;
using Book_rew.Repositories;
using Book_rew.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_rew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(p => p.AddPolicy("corsfordevelopment", builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            builder.Services.AddDbContext<AplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("RamasConnection"));//Default for GitHub
                //options.UseSqlServer(builder.Configuration.GetConnectionString("KestutisConnection"));
                //options.UseSqlServer(builder.Configuration.GetConnectionString("TadeushConnection"));
                //options.UseSqlServer(builder.Configuration.GetConnectionString("AugustasConnection"));
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService<Book>, BookDataService>(); /// Local => BookDataService; DB => BookService
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IBookInitialData, BookInitialData>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("corsfordevelopment");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
