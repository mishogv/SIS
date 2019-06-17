namespace Panda.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Receipts= new HashSet<Receipt>();
            this.Packages = new HashSet<Package>();

            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Email { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
