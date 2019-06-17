namespace SULS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission : BaseModel
    {
        [Required]
        [StringLength(800, MinimumLength = 30)]
        public string Code { get; set; }

        [Range(0, 300)]
        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public Problem Problem { get; set; }
        public string ProblemId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}