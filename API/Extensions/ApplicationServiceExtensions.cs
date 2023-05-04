using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationServices(
    this IServiceCollection services,
    IConfiguration config
  )
  {
    services.AddDbContext<DataContext>(opts =>
    {
      opts.UseSqlite(config.GetConnectionString("DefaultConnection"));
    });

    services.AddCors(
      opts =>
        opts.AddPolicy(
          "CorsPolicy",
          policy =>
          {
            policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
          }
        )
    );

    services.AddAutoMapper(typeof(Application.Activities.List.Handler).Assembly);
    services.AddMediatR(typeof(Application.Activities.List.Handler).Assembly);
    services.AddValidatorsFromAssembly(typeof(Application.Activities.List.Handler).Assembly);
    services.AddFluentValidationAutoValidation();

    return services;
  }
}
