namespace DemoRedisCache.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallerServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}