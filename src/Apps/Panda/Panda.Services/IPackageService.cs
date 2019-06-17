namespace Panda.Services
{
    using System.Collections.Generic;

    using Domain;

    using System.Linq;

    using Domain.Enums;

    public interface IPackageService
    {
        Package Create(string description, string recipientName, string shippingAddress, decimal weight);

        IQueryable<Package> GetAllForUserByStatus(string userId, PackageStatus status);

        Package Complete(string id);

        Package GetById(string id);
    }
}