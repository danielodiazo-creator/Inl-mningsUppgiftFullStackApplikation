using InlämningsUppgiftFullStackApplikation.Data;
using InlämningsUppgiftFullStackApplikation.Services;
using Microsoft.EntityFrameworkCore;

namespace InlämningsUppgiftFullStackApplikation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //Entity Framework Core configuration for SQL Server

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<TaskService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy
                        .AllowAnyOrigin()  
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend"); //SOLUCIONA EL PROBLEMA DE CORS
            app.UseAuthorization();

            app.UseStaticFiles(); //För att använda statiska filer som index.html
            app.MapControllers();

            app.Run();
        }
    }
}
