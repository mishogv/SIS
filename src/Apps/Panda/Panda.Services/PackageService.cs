namespace Panda.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using Domain;
    using Domain.Enums;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext dbContext;
        private readonly IUserService userService;

        public PackageService(PandaDbContext dbContext, IUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        public Package Create(string description, string recipientName, string shippingAddress, decimal weight)
        {
            var user = this.userService.GetUserByUsername(recipientName);

            var package = new Package()
            {
                Description = description,
                RecipientId = user.Id,
                Weight = weight,
                ShippingAddress = shippingAddress
            };

            this.dbContext.Add(package);
            this.dbContext.SaveChanges();

            return package;
        }

        public IQueryable<Package> GetAllForUserByStatus(string userId, PackageStatus status)
        {
            return this.dbContext.Packages.Where(x => x.RecipientId == userId && x.Status == status);
        }

        public Package Complete(string id)
        {
            var package = this.dbContext.Packages.SingleOrDefault(x => x.Id == id);

            if (package == null)
            {
                return null;
            }

            package.Status = PackageStatus.Delivered;

            this.dbContext.Packages.Update(package);
            this.dbContext.SaveChanges();
                
            return package;

        }

        public Package GetById(string id)
        {
            return this.dbContext.Packages.Find(id);
        }
    }
}