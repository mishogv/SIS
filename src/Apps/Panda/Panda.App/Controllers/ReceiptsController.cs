namespace Panda.App.Controllers
{
    using System.Linq;

    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Mapping;
    using SIS.MvcFramework.Result;

    using ViewModels.Receipts;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }


        [Authorize]
        public IActionResult Index()
        {
            var receipts = new ReceiptIndexViewModel
            {
                Receipts = this.receiptService
                               .GetAllByUsername(this.User.Username)
                               .Select(x => new ReceiptViewModel
                               {
                                   Id = x.Id,
                                   Fee = x.Fee.ToString("f2"),
                                   IssuedOn = x.IssuedOn.ToString(),
                                   RecipientName = x.Recipient.Username
                               })
                               .ToList()

            };

            return this.View(receipts);
        }
    }
}