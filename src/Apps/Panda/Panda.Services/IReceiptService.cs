namespace Panda.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Domain;

    public interface IReceiptService
    {
        Receipt Create(string recipientId, string packageId);

        IQueryable<Receipt> GetAllByUsername(string username);
    }
}