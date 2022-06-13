using API.Data;
using API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<Quiz> _quizCollection;
        public QuizRepository(IDataContext myWorldContext)
        {
            _quizCollection = myWorldContext.DataDb.GetCollection<Quiz>("Quizs");
        }

        public async Task<IList<Quiz>> GetAllAsync() =>
            await _quizCollection.Find(_ => true).ToListAsync();

        public async Task<Quiz?> GetByIDAsync(string id) =>
            await _quizCollection.Find(lv => lv.Id == id).FirstOrDefaultAsync();

        public async Task AddQuizAsync(Quiz creature) =>
            await _quizCollection.InsertOneAsync(creature);

        public async Task UpdateQuizAsync(string id, Quiz updatedQuiz) =>
            await _quizCollection.ReplaceOneAsync(x => x.Id == id, updatedQuiz);


        public async Task DeleteQuizAsync(string id) =>
            await _quizCollection.DeleteOneAsync(x => x.Id == id);
    }
}
