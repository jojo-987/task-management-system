namespace Application.Api.Extension;
using  Application.Infrastructure.Extension;
using   Application.AppService.Extension;
public static class StartUp
{
    public static void AddStartUpService(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddInfrastructure();
        builder.Services.AddAppService(builder.Configuration);

    }
}
