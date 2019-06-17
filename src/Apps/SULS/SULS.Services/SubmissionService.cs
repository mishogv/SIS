namespace SULS.Services
{
    using System;
    using System.Linq;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext context;
        private readonly Random random;
        private readonly IProblemService problemService;

        public SubmissionService(SULSContext sulsDbContext, Random random, IProblemService problemService)
        {
            this.context = sulsDbContext;
            this.random = random;
            this.problemService = problemService;
        }

        public int GetSubmissionsCountById(string id)
        {
            return this.context.Submissions.Count(x => x.ProblemId == id);
        }

        public IQueryable<Submission> GetSubmissionsForProblemById(string problemId)
        {
            return this.context.Submissions
                       .Include(x => x.Problem)
                       .Include(x => x.User)
                       .Where(x => x.ProblemId == problemId);
        }

        public Submission Create(string code, string problemId, string userId)
        {
            var problemMaxPoints = this.problemService.GetById(problemId).Points;

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = this.random.Next(0, problemMaxPoints)
            };

            this.context.Add(submission);

            this.context.SaveChanges();

            return submission;
        }

        public bool DeleteById(string id)
        {
            var submission = this.context.Submissions.FirstOrDefault(x => x.Id == id);

            if (submission == null)
            {
                return false;
            }

            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();

            return true;
        }
    }
}