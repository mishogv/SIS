namespace Panda.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Enums;

    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Status = PackageStatus.Pending;
        }

        public string Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public User Recipient { get; set; } 
    }
}