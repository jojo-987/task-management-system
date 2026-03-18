using Application.Infrastructure.Data;
using Application.AppService.Contract;
using Application.AppService.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.AppService.Extension;

public static class AppServiceExtension
{
    
public static void AddAppService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementSystemDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<Iservice, Service>();
    }

}
