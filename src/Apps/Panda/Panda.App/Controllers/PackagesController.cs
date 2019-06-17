namespace Panda.App.Controllers
{
    using System.Linq;

    using Domain.Enums;

    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    using ViewModels.Packages;

    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IUserService userService;
        private readonly IReceiptService receiptService;

        public PackagesController(IPackageService packageService
            , IUserService userService
            , IReceiptService receiptService)
        {
            this.packageService = packageService;
            this.userService = userService;
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var recipients = this.userService.GetAllUsernames();

            return this.View(recipients);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(CreatePackageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Create();
            }

            this.packageService.Create(input.Description, input.RecipientName, input.ShippingAddress, input.Weight);

            return this.Pending();
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = new DeliveredPackagesViewModel()
            {
                Packages = this.packageService
                               .GetAllForUserByStatus(this.User.Id, PackageStatus.Delivered)
                               .Select(x => new DeliveredPackageViewModel()
                               {
                                   Description = x.Description,
                                   ShippingAddress = x.ShippingAddress,
                                   RecipientName = x.Recipient.Username,
                                   Weight = x.Weight
                               })
                               .ToList()
            };


            return this.View(deliveredPackages);
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = new PendingPackagesViewModel()
            {
                Packages = this.packageService
                               .GetAllForUserByStatus(this.User.Id, PackageStatus.Pending)
                               .Select(x => new PendingViewModel()
                               {
                                   Description = x.Description,
                                   Id = x.Id,
                                   ShippingAddress = x.ShippingAddress,
                                   Weight = x.Weight,
                                   RecipientName = x.Recipient.Username
                               })
                               .ToList()
            };

            return this.View(pendingPackages);
        }


        [Authorize]
        public IActionResult Deliver(string id)
        {
            var package = this.packageService.Complete(id);
            this.receiptService.Create(this.User.Id, id);

            return this.Delivered();
        }

    }
}