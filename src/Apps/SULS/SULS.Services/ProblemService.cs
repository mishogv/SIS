namespace SULS.Services
{
    using System.Linq;

    using Data;

    using Models;

    public class ProblemService : IProblemService
    {
        private readonly SULSContext context;

        public ProblemService(SULSContext sulsDbContext)
        {
            this.context = sulsDbContext;
        }

        public Problem Create(string name, int points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points
            };

            this.context.Add(problem);

            this.context.SaveChanges();

            return problem;
        }

        public IQueryable<Problem> GetAll()
        {
            return this.context.Problems;
        }

        public Problem GetById(string id)
        {
            return this.context.Problems.FirstOrDefault(x => x.Id == id);
        }
    }
}