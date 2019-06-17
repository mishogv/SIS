namespace SULS.App.ViewModels.Problems
{
    using System.Collections.Generic;

    using Submissions;

    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Submissions = new List<SubmissionDetailsViewModel>();
        }

        public string Name { get; set; }

        public List<SubmissionDetailsViewModel> Submissions { get; set; }
    }
}