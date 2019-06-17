namespace Panda.Services
{
    using System;
    using System.Linq;

    using Data;

    using Domain;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext dbContext;
        private readonly IUserService userService;
        private readonly IPackageService packageService;

        public ReceiptService(PandaDbContext dbContext
                     , IUserService userService
                     , IPackageService packageService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
            this.packageService = packageService;
        }

        public Receipt Create(string recipientId, string packageId)
        {
            var package = this.packageService.GetById(packageId);

            var receipt = new Receipt()
            {
                Fee = package.Weight * 2.67m,
                IssuedOn = DateTime.UtcNow,
                PackageId = packageId,
                RecipientId = recipientId
            };

            this.dbContext.Add(receipt);
            this.dbContext.SaveChanges();

            return receipt;
        }

        public IQueryable<Receipt> GetAllByUsername(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            return this.dbContext.Receipts.Where(x => x.RecipientId == user.Id);
        }
    }
}