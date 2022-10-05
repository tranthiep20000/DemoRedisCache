namespace DemoRedisCache.Installers
{
    public interface IInstaller
    {
        public void InstallerServices(WebApplicationBuilder builder, IConfiguration configuration);
    }
}