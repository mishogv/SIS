namespace SULS.App.ViewModels.Submissions
{
    using SIS.MvcFramework.Attributes.Validation;

    public class CreateSubmissionBindingModel
    {
        private const string ErrorCode = "Invalid Code!";

        [RequiredSis]
        [StringLengthSis(30, 800, ErrorCode )]
        public string Code { get; set; }

        [RequiredSis]
        public string ProblemId { get; set; }
    }
}