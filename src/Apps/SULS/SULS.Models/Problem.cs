namespace SULS.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Problem : BaseModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Range(50, 300)]
        public int Points { get; set; }
    }
}