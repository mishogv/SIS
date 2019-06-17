namespace SULS.App.Controllers
{
    using System.Linq;

    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    using ViewModels.Problems;
    using ViewModels.Submissions;

    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public ProblemsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProblemBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Create();
            }

            var problem = this.problemService.Create(input.Name, input.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemService.GetById(id);

            var result = new ProblemDetailsViewModel()
            {
                Name = problem.Name,
                Submissions = this.submissionService.GetSubmissionsForProblemById(problem.Id)
                                  .Select(x => new SubmissionDetailsViewModel
                                  {
                                      Id = x.Id,
                                      AchievedResult = x.AchievedResult,
                                      CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                                      MaxPoints = x.Problem.Points,
                                      FinalPoints = 100,
                                      Username = x.User.Username
                                  })
                                  .ToList()
            };

            return this.View(result);
        }
    }
}