using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface IQuizRepository
    {
        Task<IList<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIDAsync(string id);
        Task AddQuizAsync(Quiz creature);
        Task UpdateQuizAsync(string id, Quiz updatedQuiz);
        Task DeleteQuizAsync(string id);
    }
}
