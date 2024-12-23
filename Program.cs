
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.Enums;
using Tabu.Exceptions;

namespace Tabu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCacheService(builder.Configuration, CacheTypes.Redis);

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddServices();
            builder.Services.AddDbContext<TabuDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MYCon"));
            });
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

            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var feature = handler.ServerFeatures.Get<IExceptionHandlerFeature>();
                    var exc = feature.Error;
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    if (exc is IBaseException ibe)
                    {
                        context.Response.StatusCode = ibe.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = ibe.StatusCode,
                            Message = ibe.ErrorMessage,
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "Nese problem var",
                        });
                    }
                });

            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
