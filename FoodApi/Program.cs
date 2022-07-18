using FoodApi.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

internal class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = "server=u1648633.plsk.regruhosting.ru;port=3306;user=u1648633_admin;password=Y79-VkR-iFi-RsX;database=u1648633_food_db;";

        builder.Services.AddDbContextPool<dbContext>(options => options
            .UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                options => options.EnableRetryOnFailure()
            )
        );
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline. 

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}