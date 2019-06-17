namespace Panda.App
{
    using Data;

    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.DependencyContainer;
    using SIS.MvcFramework.Routing;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new PandaDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IReceiptService, ReceiptService>();
            serviceProvider.Add<IPackageService, PackageService>();
        }
    }
}
