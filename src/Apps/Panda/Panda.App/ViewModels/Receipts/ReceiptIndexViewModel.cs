namespace Panda.App.ViewModels.Receipts
{
    using System.Collections.Generic;

    public class ReceiptIndexViewModel
    {
        public List<ReceiptViewModel> Receipts { get; set; } = new List<ReceiptViewModel>();
    }
}