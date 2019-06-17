namespace SULS.Services
{
    using System.Linq;

    using Models;

    public interface ISubmissionService
    {
        int GetSubmissionsCountById(string id);

        IQueryable<Submission> GetSubmissionsForProblemById(string problemId);

        Submission Create(string code, string problemId, string userId);

        bool DeleteById(string id);
    }
}