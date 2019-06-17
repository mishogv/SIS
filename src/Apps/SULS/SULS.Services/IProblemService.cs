namespace SULS.Services
{
    using System.Linq;

    using Models;

    public interface IProblemService
    {
        Problem Create(string name, int points);

        IQueryable<Problem> GetAll();

        Problem GetById(string id);
    }
}