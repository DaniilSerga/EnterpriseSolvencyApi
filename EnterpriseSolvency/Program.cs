
using EnterpriseSolvency.BusinessLogic.Services.Contracts;
using EnterpriseSolvency.BusinessLogic.Services.Implementations;
using EnterpriseSolvency.Model;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseSolvency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DataBase configuration
            string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            #endregion

            // Add services to the container.
            builder.Services.AddScoped<ISolvencyService, SolvencyService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


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
