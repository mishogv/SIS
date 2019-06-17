namespace SULS.App.Controllers
{
    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    using ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetById(id);
            var result = new CreateSubmissionViewModel {Name = problem.Name, ProblemId = problem.Id};

            return this.View(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateSubmissionBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Create(input.ProblemId);
            }

            this.submissionService.Create(input.Code, input.ProblemId, this.User.Id);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            var submission = this.submissionService.DeleteById(id);

            return this.Redirect("/");
        }
    }
}