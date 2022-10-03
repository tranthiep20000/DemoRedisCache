namespace DemoRedisCache.Installers
{
    public static class InstallerExtension
    {
        public static void InstalerServicesInAssembly(IConfiguration configuration)
        {
            var installer = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(installer => installer.InstallerServices(configuration));
        }
    }
}