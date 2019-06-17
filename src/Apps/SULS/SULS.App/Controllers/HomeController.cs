namespace SULS.App.Controllers
{
    using System.Linq;

    using Services;

    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Result;

    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public HomeController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var problems = this.problemService.GetAll();

                var result = problems.Select(x => new IndexViewModel()
                                        {
                                            Name = x.Name,
                                            Count = this.submissionService.GetSubmissionsCountById(x.Id),
                                            Id = x.Id
                                        })
                                     .ToList();

                return this.View(result, view: "IndexLoggedIn");
            }

            return this.View();
        }
    }
}