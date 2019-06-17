namespace SULS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}